using CommandLine;

namespace PasswordManagerCLI.CommandOptions.VaultEntries;

[Verb("add", HelpText = "Add new entry to a vault.")]
class AddVaultEntryOptions
{
    [Option('s', "service", Required = true)]
    public string Service { get; set; }

    [Option('l', "login", Required = true)]
    public string Login { get; set; }

    [Option('p', "password", Required = true)]
    public string Password { get; set; }
}