using System.Text;
using System.Text.Json;
using PasswordManager.Core.Entities;
using PasswordManager.Core.Helpers;

namespace PasswordManager.Core.Storages;

public class EncryptedFileVaultStorage : IVaultStorage
{
    public Vault Create(string fileName)
    {
        return new Vault(fileName);
    }

    public Vault Load(string fileName, string secret)
    {
        if (!File.Exists(fileName))
        {
            throw new Exception("Can't find vault file. Please review filename or create a new one");
        }

        try
        {
            var encryptedContent = File.ReadAllBytes(fileName);
            var content = EncryptionHelper.Decrypt(encryptedContent, secret);
            var vault = JsonSerializer.Deserialize<Vault>(content)!;
            return new Vault(fileName)
            {
                Entries = vault.Entries
            };
        }
        catch (Exception ex)
        {
            throw new Exception("Can't read, decrypt or parse the vault file", ex);
        }
    }

    public bool Save(Vault vault, string secret)
    {
        var jsonFileContent = JsonSerializer.SerializeToUtf8Bytes(vault);
        var encryptedData = EncryptionHelper.Encrypt(jsonFileContent, secret);
        File.WriteAllBytes(vault.FileName, encryptedData);
        return true;
    }
}