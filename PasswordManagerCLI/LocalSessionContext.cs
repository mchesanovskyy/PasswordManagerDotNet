using PasswordManager.Core.Entities;

namespace PasswordManagerCLI
{
    internal class LocalSessionContext
    {
        public Vault? CurrentVault { get; set; }
    }
}
