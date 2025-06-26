using PasswordManager.Core.Entities;

namespace PasswordManagerCLI
{
    internal class LocalSessionContext
    {
        private Vault? _vault = null;

        public Vault CurrentVault
        {
            get
            {
                return _vault ?? throw new Exception("Sorry, there is no vault loaded. Please load vault and try again");
            }
            set
            {
                _vault = value;
            }
        }
    }
}
