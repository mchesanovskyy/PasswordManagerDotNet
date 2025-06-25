using PasswordManager.Core.Entities;

namespace PasswordManager.Core.Storages
{
    public interface IVaultStorage
    {
        Vault Load(string filePath);
        bool Save(string filePath, Vault vault);
    }
}
