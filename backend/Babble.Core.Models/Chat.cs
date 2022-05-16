using System.Collections.ObjectModel;

namespace Babble.Core.Models;

public class Chat
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;

    public IList<User> Members { get; set; } = new Collection<User>();
    public IList<Message> Messages { get; set; } = new Collection<Message>();
}