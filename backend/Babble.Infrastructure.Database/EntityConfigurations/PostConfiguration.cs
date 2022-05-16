using Babble.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Babble.Infrastructure.Database.EntityConfigurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(x => x.Content)
            .IsRequired()
            .HasMaxLength(2500);

        builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("SELECT NOW()");

        builder.HasOne(x => x.Author)
            .WithMany(x => x.Posts);

        builder.HasMany(x => x.Comments)
            .WithOne(x => x.Post);
    }
}