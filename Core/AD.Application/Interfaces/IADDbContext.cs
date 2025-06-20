using AD.Domain.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AD.Application.Interfaces;

public interface IADDbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Rate> Rates { get; set; }
    public DbSet<Payment> Payments { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}