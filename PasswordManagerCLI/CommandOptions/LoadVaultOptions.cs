using CommandLine;

namespace PasswordManagerCLI.CommandOptions
{
    [Verb("load", HelpText = "Load vault file.")]
    class LoadVaultOptions
    {
        [Option('f', "fileName", Default = "vault.json")]
        public string FileName { get; set; }
    }

    [Verb("save", HelpText = "Save vault to a file.")]
    class SaveVaultOptions
    {
        [Option('f', "fileName", Default = "vault.json")]
        public string FileName { get; set; }
    }

    [Verb("add", HelpText = "Load vault file.")]
    class AddVaultEntryOptions
    {
        [Option('s', "service", Required = true)]
        public string Service { get; set; }

        [Option('l', "login", Required = true)]
        public string Login { get; set; }

        [Option('p', "password", Required = true)]
        public string Password { get; set; }
    }

    [Verb("print", HelpText = "Print vault entries.")]
    class PrintVaultEntriesOptions
    {
    }
}
