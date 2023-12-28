namespace Client;

public class AppSettings
{
    public string Url { get; init; } = "http://localhost:5000";
    public static AppSettings Default => new();
}