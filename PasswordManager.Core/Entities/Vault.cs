namespace PasswordManager.Core.Entities
{
    public class Vault
    {
        public Vault()
        {
            Entries = new List<PasswordEntry>(0);
        }

        public ICollection<PasswordEntry> Entries { get; set; } 
    }
}
