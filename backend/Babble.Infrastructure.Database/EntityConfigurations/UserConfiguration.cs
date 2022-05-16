using Babble.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Babble.Infrastructure.Database.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(x => x.UserName)
            .IsRequired()
            .HasMaxLength(32);

        builder.Property(x => x.Biography)
            .HasMaxLength(256);

        builder.Property(x => x.RegistryDate)
            .HasDefaultValueSql("SELECT NOW()");

        builder.HasMany(x => x.Posts)
            .WithOne(x => x.Author);
    }
}