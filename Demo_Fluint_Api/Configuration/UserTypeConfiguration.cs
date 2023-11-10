using Demo_Fluint_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo_Fluint_Api.Configuration;

public class UserTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
              .UseIdentityColumn();

        builder.Property(x => x.Name)
        .HasMaxLength(256);

        builder.HasIndex(x => x.Email)
        .IsUnique();

        builder.Property(x => x.Email)
       .IsRequired();

        builder.Property(x => x.Password)
        .IsRequired();

        builder.HasIndex(x => x.UserName)
        .IsUnique();

        builder.Property(x => x.UserName)
       .IsRequired();

    }
}
