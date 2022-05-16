using System.Reflection;
using Babble.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Babble.Infrastructure.Database;

public class BabbleContext : DbContext
{
    public BabbleContext(DbContextOptions<DbContext> options) 
        : base(options)
    {
    }

    public DbSet<Chat> Chats { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}