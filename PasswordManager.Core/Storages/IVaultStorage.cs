using PasswordManager.Core.Entities;

namespace PasswordManager.Core.Storages
{
    public interface IVaultStorage
    {
        Vault Create(string fileName);
        Vault Load(string fileName, string secret);
        bool Save(Vault vault, string secret);
    }
}
