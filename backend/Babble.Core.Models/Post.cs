using System.Collections.ObjectModel;

namespace Babble.Core.Models;

public class Post
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? EditedAt { get; set; }

    public User Author { get; set; } = null!;
    public IList<Comment> Comments { get; set; } = new Collection<Comment>();
}