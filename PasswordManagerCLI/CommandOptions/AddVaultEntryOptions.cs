using CommandLine;

namespace PasswordManagerCLI.CommandOptions;

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