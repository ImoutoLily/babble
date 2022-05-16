using Babble.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Babble.Infrastructure.Database.EntityConfigurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Content)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("SELECT NOW()");

        builder.HasOne(x => x.Author);

        builder.HasOne(x => x.Post)
            .WithMany(x => x.Comments);
    }
}