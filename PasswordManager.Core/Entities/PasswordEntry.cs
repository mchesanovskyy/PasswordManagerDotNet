namespace PasswordManager.Core.Entities;

public class PasswordEntry
{
    public int Id { get; set; } = 0;
    public string Service { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
