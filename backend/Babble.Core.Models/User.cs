using System.Collections.ObjectModel;

namespace Babble.Core.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public Gender? Gender { get; set; }
    public string? Biography { get; set; }
    public DateTime RegistryDate { get; set; }

    public IList<Post> Posts { get; set; } = new Collection<Post>();
}