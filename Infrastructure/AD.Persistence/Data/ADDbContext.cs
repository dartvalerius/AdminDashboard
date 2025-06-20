using AD.Application.Interfaces;
using AD.Domain.Entities;
using AD.Persistence.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AD.Persistence.Data;

public class ADDbContext(DbContextOptions<ADDbContext> options) : DbContext(options), IADDbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Rate> Rates { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new AccountConfiguration().Configure(modelBuilder.Entity<Account>());
        new UserProfileConfiguration().Configure(modelBuilder.Entity<UserProfile>());
        new RateConfiguration().Configure(modelBuilder.Entity<Rate>());
        new PaymentConfiguration().Configure(modelBuilder.Entity<Payment>());
    }
}