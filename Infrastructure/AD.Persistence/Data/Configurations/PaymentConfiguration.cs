using System.Globalization;

using AD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AD.Persistence.Data.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder
            .ToTable("PAYMENTS");

        builder
            .HasKey(x => x.Id);

        builder
            .HasOne(x => x.UserProfile)
            .WithMany(x => x.Payments)
            .HasForeignKey(x => x.UserProfileId);

        builder
            .HasOne(x => x.Rate)
            .WithMany(x => x.Payments)
            .HasForeignKey(x => x.RateId);

        builder
            .Property(x => x.Id)
            .HasColumnName("ID")
            .HasConversion<string>()
            .HasColumnType("TEXT")
            .IsRequired();

        builder
            .Property(x => x.DateTime)
            .HasColumnName("DATE_TIME")
            .HasColumnType("TEXT")
            .HasConversion(x => x.ToUniversalTime().ToString("o"),
                x => DateTime.Parse(x, null, DateTimeStyles.RoundtripKind));

        builder
            .Property(x => x.Amount)
            .HasColumnName("AMOUNT")
            .IsRequired();
    }
}