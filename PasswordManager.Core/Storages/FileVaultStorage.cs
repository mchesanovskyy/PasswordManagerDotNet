using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using PasswordManager.Core.Entities;

namespace PasswordManager.Core.Storages;

public static class EncryptionHelper
{
    private const int SaltSize = 16; // 128-bit
    private const int IvSize = 16;   // 128-bit
    private const int KeySize = 32;  // 256-bit AES
    private const int Iterations = 100_000;

    public static byte[] Encrypt(byte[] plainData, string password)
    {
        var salt = GenerateRandomBytes(SaltSize);
        var iv = GenerateRandomBytes(IvSize);
        var key = DeriveKey(password, salt);

        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using var encryptor = aes.CreateEncryptor();
        var cipherData = encryptor.TransformFinalBlock(plainData, 0, plainData.Length);

        // Combine: [salt]+[iv]+[cipherData]
        using var ms = new MemoryStream();
        ms.Write(salt, 0, salt.Length);
        ms.Write(iv, 0, iv.Length);
        ms.Write(cipherData, 0, cipherData.Length);
        return ms.ToArray();
    }

    public static byte[] Decrypt(byte[] encryptedData, string password)
    {
        var salt = encryptedData[..SaltSize];
        var iv = encryptedData[SaltSize..(SaltSize + IvSize)];
        var cipherData = encryptedData[(SaltSize + IvSize)..];

        var key = DeriveKey(password, salt);

        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using var decryptor = aes.CreateDecryptor();
        return decryptor.TransformFinalBlock(cipherData, 0, cipherData.Length);
    }

    private static byte[] DeriveKey(string password, byte[] salt)
    {
        using var kdf = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
        return kdf.GetBytes(KeySize);
    }

    private static byte[] GenerateRandomBytes(int length)
    {
        var bytes = new byte[length];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(bytes);
        return bytes;
    }
}

public class FileVaultStorage : IVaultStorage
{
    public Vault Create()
    {
        return new Vault();
    }

    public Vault Load(string filePath, string secret)
    {
        if (!File.Exists(filePath))
        {
            throw new Exception("Vault not exist");
        }

        try
        {
            var encryptedContent = File.ReadAllBytes(filePath);
            var content = EncryptionHelper.Decrypt(encryptedContent, secret);
            var vault = JsonSerializer.Deserialize<Vault>(content)!;
            vault.FileName = filePath;
            return vault;
        }
        catch (Exception ex)
        {
            throw new Exception("Can't decrypt or parse vault", ex);
        }
    }

    public bool Save(string filePath, Vault vault, string secret)
    {
        var jsonFileContent = JsonSerializer.SerializeToUtf8Bytes(vault);
        var encryptedData = EncryptionHelper.Encrypt(jsonFileContent, secret);
        File.WriteAllBytes(filePath, encryptedData);
        return true;
    }
}