using AD.Application.DTO.AccountDTO;
using AD.Application.Exceptions;
using AD.Application.Interfaces;
using AD.Application.Interfaces.IServices;
using AD.Application.ViewModels.Account;
using Microsoft.EntityFrameworkCore;

namespace AD.Application.Services;

public class AccountService(IADDbContext dbContext, IPasswordHasher passwordHasher) : IAccountService
{
    public async Task<AuthenticationResponse> AuthenticateAsync(AuthDto dto, CancellationToken cancellationToken = default)
    {
        var account = await dbContext.Accounts.FirstOrDefaultAsync(x => x.Email.Equals(dto.Email), cancellationToken);

        if (account is null || !passwordHasher.IsValid(dto.Password, account.PasswordHash, account.Salt))
            throw new AuthenticationException("Неверный адрес электронной почты или пароль");

        return new AuthenticationResponse
        {
            Token = "demo",
            RefreshToken = "refreshDemo"
        };
    }
}