using CommandLine;

namespace PasswordManagerCLI.CommandOptions.VaultEntries;

[Verb("remove", HelpText = "Remove vault entry record.")]
class RemoveVaultEntryOptions
{
    [Option('i', "id", Required = true)]
    public int Id { get; set; }
}