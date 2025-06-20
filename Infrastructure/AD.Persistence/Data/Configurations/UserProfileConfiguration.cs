using AD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AD.Persistence.Data.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder
            .ToTable("USER_PROFILES");

        builder
            .HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Name)
            .IsUnique();

        builder
            .HasOne(x => x.Account)
            .WithOne(x => x.UserProfile)
            .HasForeignKey<Account>(x => x.Id);

        builder
            .HasMany(x => x.Payments)
            .WithOne(x => x.UserProfile)
            .HasForeignKey(x => x.UserProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(x => x.Id)
            .HasColumnName("ID")
            .HasConversion<string>()
            .HasColumnType("TEXT")
            .IsRequired();

        builder
            .Property(x => x.Name)
            .HasColumnName("NAME")
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(x => x.Balance)
            .HasColumnName("BALANCE")
            .HasMaxLength(100)
            .IsRequired();
    }
}