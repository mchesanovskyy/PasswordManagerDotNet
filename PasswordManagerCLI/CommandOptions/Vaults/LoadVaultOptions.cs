using CommandLine;

namespace PasswordManagerCLI.CommandOptions.Vaults
{
    [Verb("load", HelpText = "Load vault file.")]
    class LoadVaultOptions
    {
        [Option('f', "fileName", Default = "vault.enc")]
        public string FileName { get; set; }
    }
}
