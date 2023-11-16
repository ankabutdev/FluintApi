using Demo_Fluint_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo_Fluint_Api.Configuration;

public class StudentTypeConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.UserName)
            .IsRequired();

        builder.HasIndex(x => x.UserName)
            .IsUnique();

        builder.Property(x => x.FirstName)
            .HasMaxLength(256);

        builder.Property(x => x.LastName)
            .HasMaxLength(256);

        builder.HasMany(x => x.Books)
            .WithOne(x => x.Student)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
