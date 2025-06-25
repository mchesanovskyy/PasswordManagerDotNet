using PasswordManager.Core.Entities;
using PasswordManager.Core.Storages;

var storage = new FileVaultStorage();
var vault = storage.Load("vault.json");

vault.Entries.Add(new PasswordEntry
{
    Service = "discord.com 2",
    Login = "mylogin",
    Password = "MySecurePass123"
});

storage.Save("vault.json", vault);

Console.WriteLine("Test Data:");
foreach (var entry in vault.Entries)
{
    Console.WriteLine($"Service: {entry.Service}, Login: {entry.Login}, Pass: {entry.Password}");
}