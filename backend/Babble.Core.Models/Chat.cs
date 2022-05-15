using System.Collections.ObjectModel;

namespace Babble.Core.Models;

public class Chat
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;

    public IList<User> Members { get; set; } = new Collection<User>();
    public IList<Message> Messages { get; set; } = new Collection<Message>();
}