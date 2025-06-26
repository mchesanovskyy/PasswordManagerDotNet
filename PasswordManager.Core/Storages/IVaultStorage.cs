using PasswordManager.Core.Entities;

namespace PasswordManager.Core.Storages
{
    public interface IVaultStorage
    {
        Vault Create();
        Vault Load(string filePath, string secret);
        bool Save(string filePath, Vault vault, string secret);
    }
}
