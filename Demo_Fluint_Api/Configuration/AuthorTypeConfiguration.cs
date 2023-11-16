using Demo_Fluint_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo_Fluint_Api.Configuration;

public class AuthorTypeConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(200);

        builder.HasMany(x => x.Books)
            .WithOne(x => x.Author)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
