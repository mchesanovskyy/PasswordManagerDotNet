using System.Text.RegularExpressions;

var application = new CLIApplication();
while (true)
{
    Console.Write(":> ");
    var argumentsInput = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(argumentsInput))
    {
        Console.WriteLine("no args");
        continue;
    }

    var arguments = SplitArguments(argumentsInput);
    application.Run(arguments);
}

static string[] SplitArguments(string input)
{
    var matches = Regex.Matches(input, @"[\""].+?[\""]|[^ ]+")
        .Select(m => m.Value.Trim('"'))
        .ToArray();
    return matches;
}