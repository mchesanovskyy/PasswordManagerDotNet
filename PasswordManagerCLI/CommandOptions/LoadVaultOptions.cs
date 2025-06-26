using CommandLine;

namespace PasswordManagerCLI.CommandOptions
{
    [Verb("load", HelpText = "Load vault file.")]
    class LoadVaultOptions
    {
        [Option('f', "fileName", Default = "vault.enc")]
        public string FileName { get; set; }
    }

    [Verb("create", HelpText = "Create vault file.")]
    class CreateVaultOptions
    {
        [Option('f', "fileName", Default = "vault.enc")]
        public string FileName { get; set; }
    }
}
