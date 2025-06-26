namespace PasswordManager.Core.Entities
{
    public class Vault
    {
        public Vault()
        {
            Entries = new List<PasswordEntry>(0);
        }

        public string FileName { get; set; } = string.Empty;
        public ICollection<PasswordEntry> Entries { get; set; } 
    }
}
