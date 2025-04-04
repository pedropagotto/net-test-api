using Authentication.Domain.Entities;
using Authentication.Domain.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Infrastructure.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(x => x.Authentication)
            .WithOne(a => a.User)
            .HasForeignKey<Auth>(a => a.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Age)
            .IsRequired(false)
            .HasMaxLength(3);

        builder.Property(x => x.Address)
            .IsRequired(false)
            .HasMaxLength(100);

        builder.Property(x => x.OtherInfo)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Interests)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Feelings)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.ValuesDescription)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .IsRequired(false);

        builder.Property(x => x.CreatedBy)
            .IsRequired();

        builder.Property(x => x.UpdatedBy)
            .IsRequired(false);
    }
}
