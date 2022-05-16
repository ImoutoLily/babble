namespace Babble.Core.Models;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? EditedAt { get; set; }

    public User Author { get; set; } = null!;
    public Post Post { get; set; } = null!;
}