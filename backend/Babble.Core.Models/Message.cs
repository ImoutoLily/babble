namespace Babble.Core.Models;

public class Message
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;

    public User Author { get; set; } = null!;
    public Chat Chat { get; set; } = null!;
}