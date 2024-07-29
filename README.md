![Capture](https://github.com/user-attachments/assets/d14f279f-9ab0-47f6-97c1-0259455d60d2)
# EncryptMe

EncryptMe is a Windows Forms application that encrypts executable files and generates a stub to decrypt and execute the original file at runtime. The program uses AES encryption to secure the file and optionally adds a digital signature to the output executable.

## Features

- Browse for an input executable file to encrypt.
- Generate a random AES key and initialization vector (IV).
- Encrypt the input file and save the encrypted file to a specified location.
- Generate a stub that decrypts the file at runtime.
- Optionally, sign the output executable using a donor executable.

## Requirements

- .NET Framework 4.0 or later.
- Python (for optional digital signing).

## Installation

1. Clone the repository or download the source code.
2. Open the project in Visual Studio.
3. Build the solution.

## Usage

1. Run the compiled application.
2. Use the "Browse" button to select an executable file to encrypt.
3. Use the "Browse Save Path" button to specify where to save the encrypted file.
4. Use the "Browse Donor Exe" button to select a donor executable for signing (optional).
5. Click the "Generate Key, IV, and Passphrase" button to generate encryption parameters.
6. Click the "Encrypt" button to encrypt the file and generate the stub.
7. The status box will display messages about the process, including any errors.

## File Structure

- **Form1.cs**: The main form logic, including the encryption and stub generation process.
- **Program.cs**: The program entry point.

## Encryption Details

- AES encryption is used to secure the input file.
- A random passphrase is generated for additional security.
- The encrypted file is base64 encoded and embedded in a stub.
- The stub decrypts and decompresses the original file at runtime.

## Key Functions

### btnBrowse_Click

Allows the user to select an executable file to encrypt.

### btnBrowseSavePath_Click

Allows the user to specify where to save the encrypted file.

### btnBrowseDonorExe_Click

Allows the user to select a donor executable for signing.

### btnGenerateKeyIV_Click

Generates a random AES key, IV, and passphrase.

### btnEncrypt_Click

Encrypts the input file, generates the stub, and optionally signs the output executable.

### Encrypt

Encrypts data using AES.

### EncryptWithPassphrase

Encrypts data with an additional passphrase.

### GenerateRandomPassphrase

Generates a random passphrase for encryption.

### GenerateStubSource

Generates the stub source code for decrypting and executing the encrypted file.

### RunPythonScript

Runs a Python script to sign the output executable using a donor executable.

## Terms of Service

By using this software, you agree to the following terms:

- The software is provided "as is," without warranty of any kind, express or implied, including but not limited to the warranties of merchantability, fitness for a particular purpose, and noninfringement.
- The author takes no responsibility for any damage that may arise from the use of this software.
- The user assumes all responsibility for ensuring compliance with all applicable laws and regulations when using this software.
- The author is not liable for any misuse of this software or any illegal activities conducted with it.

![Capture](https://github.com/user-attachments/assets/693bb6a0-524b-4415-80f2-1d9dd6e804e2)

## License

This project is licensed under the MIT License.



## Donate and Ill make it FUD. 

Tron Address: TYa6hbouPRdMG7GyHBng6tgPFwTgiiokiV
