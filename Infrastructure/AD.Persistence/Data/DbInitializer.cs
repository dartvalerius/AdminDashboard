using AD.Domain.Entities;
using AD.Persistence.Security;

namespace AD.Persistence.Data;

public class DbInitializer
{
    public static void Initialize(ADDbContext context)
    {
        if (context.Accounts.Any() || context.UserProfiles.Any() || context.Rates.Any() || context.Payments.Any()) return;

        var passwordHasher = new PasswordHasher();

        var saltAdminAccount = passwordHasher.GenerateSalt();
        var saltClientOneAccount = passwordHasher.GenerateSalt();
        var saltClientTwoAccount = passwordHasher.GenerateSalt();
        var saltClientTreeAccount = passwordHasher.GenerateSalt();

        var adminAccount = new Account
        {
            Id = Guid.NewGuid(),
            Email = "admin@mirra.dev",
            PasswordHash = passwordHasher.Hash("admin123", saltAdminAccount),
            Salt = saltAdminAccount,
            Role = RoleTypes.Admin
        };

        var clientOneAccount = new Account
        {
            Id = Guid.NewGuid(),
            Email = "clientOne@mirra.dev",
            PasswordHash = passwordHasher.Hash("clientOne123", saltClientOneAccount),
            Salt = saltClientOneAccount,
            Role = RoleTypes.Client
        };

        var clientTwoAccount = new Account
        {
            Id = Guid.NewGuid(),
            Email = "clientTwo@mirra.dev",
            PasswordHash = passwordHasher.Hash("clientTwo123", saltClientTwoAccount),
            Salt = saltClientTwoAccount,
            Role = RoleTypes.Client
        };

        var clientTreeAccount = new Account
        {
            Id = Guid.NewGuid(),
            Email = "clientTree@mirra.dev",
            PasswordHash = passwordHasher.Hash("clientTree123", saltClientTreeAccount),
            Salt = saltClientTreeAccount,
            Role = RoleTypes.Client
        };

        context.Accounts.AddRange(adminAccount, clientOneAccount, clientTwoAccount, clientTreeAccount);

        var adminProfiler = new UserProfile
        {
            Name = "AdminProfiler",
            Balance = 10_000_000,
            Account = adminAccount
        };

        var clientOneProfiler = new UserProfile
        {
            Name = "ClientOneProfiler",
            Balance = 100,
            Account = clientOneAccount
        };

        var clientTwoProfiler = new UserProfile
        {
            Name = "ClientTwoProfiler",
            Balance = 50,
            Account = clientTwoAccount
        };

        var clientTreeProfiler = new UserProfile
        {
            Name = "ClientTreeProfiler",
            Balance = 25,
            Account = clientTreeAccount
        };

        context.UserProfiles.AddRange(adminProfiler, clientOneProfiler, clientTwoProfiler, clientTreeProfiler);

        var rate1 = new Rate()
        {
            Id = Guid.NewGuid(),
            DateSet = new DateTime(2025, 6, 1),
            CurrentRate = 5
        };

        var rate2 = new Rate()
        {
            Id = Guid.NewGuid(),
            DateSet = new DateTime(2025, 6, 7),
            CurrentRate = 10
        };

        context.Rates.AddRange(rate1, rate2);

        var payment1 = new Payment
        {
            Id = Guid.NewGuid(),
            DateTime = new DateTime(2025, 6, 2),
            Amount = 250,
            Rate = rate1,
            UserProfile = clientOneProfiler
        };

        var payment2 = new Payment
        {
            Id = Guid.NewGuid(),
            DateTime = new DateTime(2025, 6, 2),
            Amount = 150,
            Rate = rate1,
            UserProfile = clientTwoProfiler
        };

        var payment3 = new Payment
        {
            Id = Guid.NewGuid(),
            DateTime = new DateTime(2025, 6, 2),
            Amount = 75,
            Rate = rate1,
            UserProfile = clientTreeProfiler
        };

        var payment4 = new Payment
        {
            Id = Guid.NewGuid(),
            DateTime = new DateTime(2025, 6, 8),
            Amount = 500,
            Rate = rate2,
            UserProfile = clientOneProfiler
        };

        var payment5 = new Payment
        {
            Id = Guid.NewGuid(),
            DateTime = new DateTime(2025, 6, 8),
            Amount = 200,
            Rate = rate2,
            UserProfile = clientTwoProfiler
        };

        var payment6 = new Payment
        {
            Id = Guid.NewGuid(),
            DateTime = new DateTime(2025, 6, 8),
            Amount = 100,
            Rate = rate2,
            UserProfile = clientTreeProfiler
        };

        context.Payments.AddRange(payment1, payment2, payment3, payment4, payment5, payment6);

        context.SaveChanges();
    }
}