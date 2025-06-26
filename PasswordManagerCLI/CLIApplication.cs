using CommandLine;
using PasswordManager.Core.Storages;
using PasswordManagerCLI.CommandHandlers;
using PasswordManagerCLI.CommandHandlers.VaultEntries;
using PasswordManagerCLI.CommandHandlers.Vaults;
using PasswordManagerCLI.CommandOptions.VaultEntries;
using PasswordManagerCLI.CommandOptions.Vaults;

namespace PasswordManagerCLI;

class CLIApplication
{
    private readonly LocalSessionContext _sessionContext;
    private readonly EncryptedFileVaultStorage _vaultStorage;
    public CLIApplication()
    {
        _sessionContext = new LocalSessionContext();
        _vaultStorage = new EncryptedFileVaultStorage();
    }

    public void Run(string[] args)
    {
        try
        {
            Parser.Default.ParseArguments<LoadVaultOptions, AddVaultEntryOptions, SaveVaultOptions, PrintVaultEntriesOptions, 
                    CreateVaultOptions, ShowVaultEntryOptions, RemoveVaultEntryOptions>(args)
                .WithParsed<CreateVaultOptions>(options => new CreateVaultCommandHandler(_vaultStorage).Process(options, _sessionContext))
                .WithParsed<LoadVaultOptions>(options => new LoadVaultCommandHandler(_vaultStorage).Process(options, _sessionContext))
                .WithParsed<SaveVaultOptions>(options => new SaveVaultCommandHandler(_vaultStorage).Process(options, _sessionContext))
                .WithParsed<AddVaultEntryOptions>(options => new AddVaultEntryCommandHandler().Process(options, _sessionContext))
                .WithParsed<PrintVaultEntriesOptions>(options => new PrintVaultCommandHandler().Process(options, _sessionContext))
                .WithParsed<RemoveVaultEntryOptions>(options => new RemoveVaultEntryCommandHandler().Process(options, _sessionContext))
                .WithParsed<ShowVaultEntryOptions>(options => new ShowVaultEntryCommandHandler().Process(options, _sessionContext));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}