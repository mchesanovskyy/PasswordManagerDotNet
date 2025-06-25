using System.Text.Json;
using PasswordManager.Core.Entities;

namespace PasswordManager.Core.Storages;

public class FileVaultStorage : IVaultStorage
{
    public Vault Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new Vault();
        }

        var content = File.ReadAllText(filePath);
        return TryParseJsonContent(content)
               ?? new Vault();
    }

    public bool Save(string filePath, Vault vault)
    {
        var jsonFileContent = JsonSerializer.Serialize(vault);
        File.WriteAllText(filePath, jsonFileContent);
        return true;
    }

    protected Vault? TryParseJsonContent(string content)
    {
        try
        {
            return JsonSerializer.Deserialize<Vault>(content);
        }
        catch (Exception ex)
        {
            // TODO: log error; otherwise it can be difficult to know what went wrong if smth wrong with the file format
            return null;
        }
    }
}