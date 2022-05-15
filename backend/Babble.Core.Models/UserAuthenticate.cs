namespace Babble.Core.Models;

public class UserAuthenticate
{
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public string Password { get; set; } = null!;
}