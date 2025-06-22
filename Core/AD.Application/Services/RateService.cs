using AD.Application.DTO.RateDTO;
using AD.Application.Interfaces;
using AD.Application.Interfaces.IServices;
using AD.Application.ViewModels.Rate;
using AD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AD.Application.Services;

public class RateService(IADDbContext dbContext) : IRateService
{
    public async Task<RateVm> GetCurrentAsync(CancellationToken cancellationToken = default)
    {
        var lastRate = await dbContext.Rates.OrderByDescending(x => x.DateSet).LastOrDefaultAsync(cancellationToken);

        if (lastRate is null) throw new Exception("Нет данных о курсах");

        return new RateVm
        {
            Id = lastRate.Id.ToString("N"),
            DateSet = lastRate.DateSet.ToString("dd.MM.yyyy"),
            CurrentRate = lastRate.CurrentRate.ToString("##.###")
        };
    }

    public async Task CreateAsync(CreateRateDto dto, CancellationToken cancellationToken = default)
    {
        dbContext.Rates.Add(new Rate
        {
            Id = Guid.NewGuid(),
            CurrentRate = dto.Rate,
            DateSet = DateTime.Now
        });

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}