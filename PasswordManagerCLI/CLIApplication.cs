using CommandLine;
using PasswordManager.Core.Entities;
using PasswordManager.Core.Storages;
using PasswordManagerCLI;
using PasswordManagerCLI.CommandOptions;
using PasswordManagerCLI.Helpers;

class CLIApplication
{
    private readonly LocalSessionContext _sessionContext;

    public CLIApplication()
    {
        _sessionContext = new LocalSessionContext();
    }

    public void Run(string[] args)
    {
        try
        {
            Parser.Default.ParseArguments<LoadVaultOptions, AddVaultEntryOptions, SaveVaultOptions,
                    PrintVaultEntriesOptions, CreateVaultOptions>(args)
                .WithParsed<LoadVaultOptions>(options => LoadVault(options, _sessionContext))
                .WithParsed<AddVaultEntryOptions>(options => AddVaultEntry(options, _sessionContext))
                .WithParsed<SaveVaultOptions>(options => SaveVault(options, _sessionContext))
                .WithParsed<PrintVaultEntriesOptions>(options => PrintVault(options, _sessionContext))
                .WithParsed<CreateVaultOptions>(options => CreateVault(options, _sessionContext));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private void CreateVault(CreateVaultOptions options, LocalSessionContext sessionContext)
    {
        sessionContext.CurrentVault = new Vault
        {
            FileName = options.FileName
        };
    }

    private void PrintVault(PrintVaultEntriesOptions options, LocalSessionContext sessionContext)
    {
        if (sessionContext.CurrentVault == null)
        {
            Console.WriteLine("Sorry, there is no vault loaded. Please load vault and try again");
            return;
        }

        foreach (var entry in sessionContext.CurrentVault.Entries)
        {
            Console.WriteLine($"Service: {entry.Service}, Login: {entry.Login}, Password: ***");
        }
    }

    private void SaveVault(SaveVaultOptions options, LocalSessionContext sessionContext)
    {
        if (sessionContext.CurrentVault == null)
        {
            Console.WriteLine("Sorry, there is no vault loaded. Please load vault and try again");
            return;
        }

        var secret = ConsoleHelper.ReadSecretFromConsole();
        var vaultStorage = new FileVaultStorage();
        vaultStorage.Save(options.FileName, sessionContext.CurrentVault, secret);
        Console.WriteLine("Vault saved");
    }

    private void AddVaultEntry(AddVaultEntryOptions options, LocalSessionContext sessionContext)
    {
        if (sessionContext.CurrentVault == null)
        {
            Console.WriteLine("Sorry, there is no vault loaded. Please load vault and try again");
            return;
        }

        var entry = new PasswordEntry()
        {
            Service = options.Service,
            Login = options.Login,
            Password = options.Password,
        };
        sessionContext.CurrentVault.Entries.Add(entry);
    }

    private void LoadVault(LoadVaultOptions options, LocalSessionContext sessionContext)
    {
        var secret = ConsoleHelper.ReadSecretFromConsole();

        var vaultStorage = new FileVaultStorage();
        var vault = vaultStorage.Load(options.FileName, secret);
        sessionContext.CurrentVault = vault;
        Console.WriteLine("Vault loaded");
    }
}