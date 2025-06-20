using System.Globalization;
using AD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AD.Persistence.Data.Configurations;

public class RateConfiguration : IEntityTypeConfiguration<Rate>
{
    public void Configure(EntityTypeBuilder<Rate> builder)
    {
        builder
            .ToTable("RATES");

        builder
            .HasKey(x => x.Id);

        builder
            .HasMany(x => x.Payments)
            .WithOne(x => x.Rate)
            .HasForeignKey(x => x.RateId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(x => x.Id)
            .HasColumnName("ID")
            .HasConversion<string>()
            .HasColumnType("TEXT")
            .IsRequired();

        builder
            .Property(x => x.DateSet)
            .HasColumnName("DATE_SET")
            .HasColumnType("TEXT")
            .HasConversion(x => x.ToUniversalTime().ToString("o"),
                x => DateTime.Parse(x, null, DateTimeStyles.RoundtripKind));

        builder
            .Property(x => x.CurrentRate)
            .HasColumnName("CURRENT_RATE")
            .IsRequired();
    }
}