using Authentication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Infrastructure.Configurations;

public class AuthConfigurations : IEntityTypeConfiguration<Auth>
{
    public void Configure(EntityTypeBuilder<Auth> builder)
    {
        builder.ToTable("Authentication");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasIndex(x => x.UserId).IsUnique();

        builder.OwnsOne(x => x.Email, email =>
        {
            email.Property(e => e.Value)
                .IsRequired()
                .HasColumnName("Email")
                .HasMaxLength(160);
        });

        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .IsRequired(false);

        builder.Property(x => x.CreatedBy)
            .IsRequired();

        builder.Property(x => x.UpdatedBy)
            .IsRequired();
    }
}
