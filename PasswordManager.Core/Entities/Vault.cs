namespace PasswordManager.Core.Entities
{
    public class Vault
    {
        public Vault(string fileName)
        {
            FileName = fileName;
            Entries = new List<PasswordEntry>(0);
        }

        public string FileName { get; }
        public ICollection<PasswordEntry> Entries { get; set; } 
    }
}
