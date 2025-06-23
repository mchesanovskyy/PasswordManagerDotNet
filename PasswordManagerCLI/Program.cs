
using PasswordManager.Core.Entities;

var vault = new Vault();

vault.Entries.Add(new PasswordEntry
{
    Service = "gmail.com",
    Login = "user@gmail.com",
    Password = "qwerty123"
});

vault.Entries.Add(new PasswordEntry
{
    Service = "github.com",
    Login = "dev123",
    Password = "securePass!"
});

Console.WriteLine("Test Data:");
foreach (var entry in vault.Entries)
{
    Console.WriteLine($"Service: {entry.Service}, Login: {entry.Login}, Pass: {entry.Password}");
}