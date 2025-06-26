using PasswordManagerCLI.CommandOptions.VaultEntries;

namespace PasswordManagerCLI.CommandHandlers.VaultEntries;

internal class RemoveVaultEntryCommandHandler : ICommandHandler<RemoveVaultEntryOptions>
{
    public void Process(RemoveVaultEntryOptions options, LocalSessionContext sessionContext)
    {
        var entry = sessionContext.CurrentVault.Entries.FirstOrDefault(e => e.Id == options.Id);
        if (entry == null)
        {
            throw new Exception("Can't find entry by id");
        }

        sessionContext.CurrentVault.Entries.Remove(entry);
        Console.WriteLine("Entry removed. Please don't forget to save vault before closing the app");
    }
}