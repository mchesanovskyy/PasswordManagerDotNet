using PasswordManagerCLI.CommandOptions.VaultEntries;

namespace PasswordManagerCLI.CommandHandlers.VaultEntries;

internal class PrintVaultCommandHandler : ICommandHandler<PrintVaultEntriesOptions>
{
    public void Process(PrintVaultEntriesOptions options, LocalSessionContext sessionContext)
    {
        foreach (var entry in sessionContext.CurrentVault.Entries)
        {
            Console.WriteLine($"Id: {entry.Id}, Service: {entry.Service}, Login: {entry.Login}, Password: ***");
        }
    }
}