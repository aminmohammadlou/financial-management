namespace Data.Models;

public sealed class SettingsModel
{
    public int Id { get; init; }
    public string? LastUserLoggedInEmail { get; set; }
}