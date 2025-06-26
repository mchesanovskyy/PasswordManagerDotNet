using CommandLine;

namespace PasswordManagerCLI.CommandOptions.Vaults;

[Verb("create", HelpText = "Create vault file.")]
class CreateVaultOptions
{
    [Option('f', "fileName", Default = "vault.enc")]
    public string FileName { get; set; }
}