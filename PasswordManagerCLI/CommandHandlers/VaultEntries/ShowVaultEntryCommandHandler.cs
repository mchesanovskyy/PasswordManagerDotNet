using PasswordManagerCLI.CommandOptions.VaultEntries;

namespace PasswordManagerCLI.CommandHandlers.VaultEntries;

internal class ShowVaultEntryCommandHandler : ICommandHandler<ShowVaultEntryOptions>
{
    public void Process(ShowVaultEntryOptions options, LocalSessionContext sessionContext)
    {
        var entry = sessionContext.CurrentVault.Entries.FirstOrDefault(e => e.Id == options.Id);
        if (entry == null)
        {
            throw new Exception("Can't find entry by id");
        }

        Console.WriteLine($"Id: {entry.Id}");
        Console.WriteLine($"Service: {entry.Service}");
        Console.WriteLine($"Login: {entry.Login}");
        Console.WriteLine($"Password: {entry.Password}");

        Console.WriteLine($"Press any key to hide the entry details...");
        Console.ReadKey();
        Console.Clear();
        
    }
}