namespace Babble.Core.Models;

public class Message
{
    public string Id { get; set; } = null!;
    public string Content { get; set; } = null!;

    public User Author { get; set; } = null!;
    public Chat Chat { get; set; } = null!;
}