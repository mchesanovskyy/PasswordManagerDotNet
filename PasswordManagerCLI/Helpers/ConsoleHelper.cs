namespace PasswordManagerCLI.Helpers
{
    class ConsoleHelper
    {
        public static string ReadSecretFromConsole(string prompt = "Enter password: ")
        {
            Console.Write(prompt);
            var password = new Stack<char>();

            ConsoleKeyInfo key;

            while (true)
            {
                key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace && password.Count > 0)
                {
                    password.Pop();
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password.Push(key.KeyChar);
                    Console.Write("*");
                }
            }

            return new string(password.Reverse().ToArray());
        }
    }
}
