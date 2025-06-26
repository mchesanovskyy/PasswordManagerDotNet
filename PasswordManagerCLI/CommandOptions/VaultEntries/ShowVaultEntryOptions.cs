using CommandLine;

namespace PasswordManagerCLI.CommandOptions.VaultEntries;

[Verb("show", HelpText = "Load vault file.")]
class ShowVaultEntryOptions
{
    [Option("id", Required = true)]
    public int Id { get; set; }
}