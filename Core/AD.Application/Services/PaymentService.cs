using System.Collections.Concurrent;
using AD.Application.Interfaces;
using AD.Application.Interfaces.IServices;
using AD.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AD.Application.Services;

public class PaymentService(IADDbContext dbContext) : IPaymentService
{
    public async Task<IList<PaymentVm>> ListAsync(int takeLast = 0, CancellationToken cancellationToken = default)
    {
        var payments = await dbContext.Payments.TakeLast(takeLast).Include(x => x.Rate).Include(x => x.UserProfile)
            .Include(x => x.UserProfile.Account).ToListAsync(cancellationToken: cancellationToken);

        return payments.Select(payment => new PaymentVm
            {
                DateTime = payment.DateTime.ToString("dd.MM.yyyy"),
                Amount = payment.Amount.ToString("##.###"),
                Rate = payment.Rate.CurrentRate.ToString("##.###"),
                UserName = payment.UserProfile.Name,
                UserEmail = payment.UserProfile.Account.Email
            })
            .ToList();
    }
}