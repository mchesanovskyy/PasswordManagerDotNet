using PasswordManager.Core.Storages;
using PasswordManagerCLI.CommandOptions.Vaults;
using PasswordManagerCLI.Helpers;

namespace PasswordManagerCLI.CommandHandlers.Vaults;

internal class LoadVaultCommandHandler : ICommandHandler<LoadVaultOptions>
{
    private readonly IVaultStorage _vaultStorage;

    public LoadVaultCommandHandler(IVaultStorage vaultStorage)
    {
        _vaultStorage = vaultStorage;
    }

    public void Process(LoadVaultOptions options, LocalSessionContext sessionContext)
    {
        var secret = ConsoleHelper.ReadSecretFromConsole();
        var vault = _vaultStorage.Load(options.FileName, secret);
        sessionContext.CurrentVault = vault;
        Console.WriteLine("Vault loaded");
    }
}