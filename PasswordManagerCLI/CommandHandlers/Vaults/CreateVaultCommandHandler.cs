using PasswordManager.Core.Storages;
using PasswordManagerCLI.CommandOptions.Vaults;

namespace PasswordManagerCLI.CommandHandlers.Vaults;

internal class CreateVaultCommandHandler : ICommandHandler<CreateVaultOptions>
{
    private readonly IVaultStorage _vaultStorage;

    public CreateVaultCommandHandler(IVaultStorage vaultStorage)
    {
        _vaultStorage = vaultStorage;
    }

    public void Process(CreateVaultOptions options, LocalSessionContext sessionContext)
    {
        sessionContext.CurrentVault = _vaultStorage.Create(options.FileName);
    }
}