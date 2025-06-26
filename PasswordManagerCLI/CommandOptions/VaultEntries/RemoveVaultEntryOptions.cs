using CommandLine;

namespace PasswordManagerCLI.CommandOptions.VaultEntries;

[Verb("remove", HelpText = "Load vault file.")]
class RemoveVaultEntryOptions
{
    [Option("id", Required = true)]
    public int Id { get; set; }
}