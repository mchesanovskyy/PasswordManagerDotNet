using CommandLine;

namespace PasswordManagerCLI.CommandOptions.Vaults;

[Verb("save", HelpText = "Save vault to a file.")]
class SaveVaultOptions
{
    [Option('f', "fileName", Default = "vault.enc")]
    public string FileName { get; set; }
}