namespace Data.Models;

public sealed class UserModel
{
    public int Id { get; init; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; init; }
    public required string Password { get; set; }
    public string? PhoneNumber { get; set; }
}