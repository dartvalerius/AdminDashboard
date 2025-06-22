using AD.Application.DTO.ClientDTO;
using AD.Application.Exceptions;
using AD.Application.Interfaces;
using AD.Application.Interfaces.IServices;
using AD.Application.ViewModels.Client;
using AD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AD.Application.Services;

public class ClientService(
    IADDbContext dbContext,
    IPasswordHasher passwordHasher) : IClientService
{
    public async Task<string> CreateAsync(CreateClientDto dto, CancellationToken cancellationToken)
    {
        var salt = passwordHasher.GenerateSalt();

        var account = new Account
        {
            Id = Guid.NewGuid(),
            Email = dto.Email,
            PasswordHash = passwordHasher.Hash(dto.Password, salt),
            Salt = salt,
            Role = RoleTypes.Client,
        };

        var userProfile = new UserProfile
        {
            Name = dto.Name,
            Account = account
        };

        dbContext.Accounts.Add(account);
        dbContext.UserProfiles.Add(userProfile);

        await dbContext.SaveChangesAsync(cancellationToken);

        return account.Id.ToString("N");
    }

    public async Task UpdateAsync(UpdateClientDto dto, CancellationToken cancellationToken)
    {
        var client = await dbContext.UserProfiles
            .Include(x => x.Account)
            .FirstOrDefaultAsync(x => x.Id == dto.Id, cancellationToken: cancellationToken);

        if (client is null) throw new NotFoundException("Клиент не найден");

        client.Name = dto.Name;
        client.Account.Email = dto.Email;

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var client = await dbContext.UserProfiles
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);

        if (client is null) throw new NotFoundException("Клиент не найден");

        dbContext.UserProfiles.Remove(client);

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<ClientListVm> ListAsync(CancellationToken cancellationToken = default)
    {
        return new ClientListVm
        {
            Clients = await dbContext.UserProfiles
                .Include(x => x.Account)
                .Select(x => new ClientListItemVm
                {
                    Id = x.Id.ToString("N"),
                    Name = x.Name,
                    Email = x.Account.Email,
                    Balance = x.Balance.ToString("##.###")
                }).ToListAsync(cancellationToken: cancellationToken),
            Count = dbContext.UserProfiles.Count()
        };
    }
}