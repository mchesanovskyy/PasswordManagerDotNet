using CommandLine;

namespace PasswordManagerCLI.CommandOptions.VaultEntries;

[Verb("show", HelpText = "Show vault entry record.")]
class ShowVaultEntryOptions
{
    [Option('i', "id", Required = true)]
    public int Id { get; set; }
}