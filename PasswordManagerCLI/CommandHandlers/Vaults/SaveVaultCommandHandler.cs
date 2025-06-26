using PasswordManager.Core.Storages;
using PasswordManagerCLI.CommandOptions.Vaults;
using PasswordManagerCLI.Helpers;

namespace PasswordManagerCLI.CommandHandlers.Vaults;

internal class SaveVaultCommandHandler : ICommandHandler<SaveVaultOptions>
{
    private readonly IVaultStorage _vaultStorage;

    public SaveVaultCommandHandler(IVaultStorage vaultStorage)
    {
        _vaultStorage = vaultStorage;
    }

    public void Process(SaveVaultOptions options, LocalSessionContext sessionContext)
    {
        var secret = ConsoleHelper.ReadSecretFromConsole();
        _vaultStorage.Save(sessionContext.CurrentVault!, secret);
        Console.WriteLine("Vault saved");
    }
}