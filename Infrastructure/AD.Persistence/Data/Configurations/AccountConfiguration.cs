using AD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AD.Persistence.Data.Configurations;

internal class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder
            .ToTable("ACCOUNTS");

        builder
            .HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Email)
            .IsUnique();

        builder
            .HasOne(x => x.UserProfile)
            .WithOne(x => x.Account)
            .HasForeignKey<UserProfile>(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasColumnName("ID")
            .HasConversion<string>()
            .HasColumnType("TEXT")
            .IsRequired();

        builder
            .Property(x => x.Email)
            .HasColumnName("EMAIL")
            .HasMaxLength(300)
            .IsRequired();

        builder
            .Property(x => x.PasswordHash)
            .HasColumnName("PASSWORD_HASH")
            .HasMaxLength(128)
            .IsFixedLength()
            .IsRequired();

        builder
            .Property(x => x.Salt)
            .HasColumnName("SALT")
            .HasMaxLength(128)
            .IsFixedLength()
            .IsRequired();

        builder
            .Property(x => x.Role)
            .HasColumnName("ROLE")
            .IsRequired();
    }
}