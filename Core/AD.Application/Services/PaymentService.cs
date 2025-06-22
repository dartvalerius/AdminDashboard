using AD.Application.Interfaces;
using AD.Application.Interfaces.IServices;
using AD.Application.ViewModels.Payment;
using Microsoft.EntityFrameworkCore;

namespace AD.Application.Services;

public class PaymentService(IADDbContext dbContext) : IPaymentService
{
    public async Task<PaymentListVm> ListAsync(int take = 0, CancellationToken cancellationToken = default)
    {
        var payments = await dbContext.Payments
            .OrderByDescending(x => x.DateTime)
            .Take(take)
            .Include(x => x.Rate)
            .Include(x => x.UserProfile)
            .Include(x => x.UserProfile.Account)
            .ToListAsync(cancellationToken: cancellationToken);

        return new PaymentListVm
        {
            Payments = payments
                .Select(payment => new PaymentListItemVm
                {
                    Id = payment.Id.ToString("N"),
                    DateTime = payment.DateTime.ToString("dd.MM.yyyy"),
                    Amount = payment.Amount.ToString("##.###"),
                    Rate = payment.Rate.CurrentRate.ToString("##.###"),
                    UserName = payment.UserProfile.Name,
                    UserEmail = payment.UserProfile.Account.Email
                })
                .ToList(),
            Count = dbContext.Payments.Count(),
            Take = take
        };
    }
}