using System.Text.Json;

namespace UniversityApp.DAL.DB;

public class DbConfig
{
    public string Host { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Database { get; set; }

    public override string ToString()
    {
        return $"Host={Host};Username={Username};Password={Password}s;Database={Database}";
    }

    public static DbConfig? Import(string path = "db_config.json")
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<DbConfig>(json);
    }
}