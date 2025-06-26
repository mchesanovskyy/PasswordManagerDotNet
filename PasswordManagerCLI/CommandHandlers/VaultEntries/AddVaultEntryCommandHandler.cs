using PasswordManager.Core.Entities;
using PasswordManagerCLI.CommandOptions.VaultEntries;

namespace PasswordManagerCLI.CommandHandlers.VaultEntries;

internal class AddVaultEntryCommandHandler : ICommandHandler<AddVaultEntryOptions>
{
    public void Process(AddVaultEntryOptions options, LocalSessionContext sessionContext)
    {
        var maxId = NextMaxId(sessionContext);
        
        var entry = new PasswordEntry
        {
            Id = maxId,
            Service = options.Service,
            Login = options.Login,
            Password = options.Password,
        };

        sessionContext.CurrentVault.Entries.Add(entry);
    }

    private static int NextMaxId(LocalSessionContext sessionContext)
    {
        if (sessionContext.CurrentVault.Entries.Any())
        {
            return sessionContext.CurrentVault.Entries.Max(e => e.Id) + 1;
        }

        return 1;
    }
}