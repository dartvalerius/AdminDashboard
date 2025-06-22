namespace AD.Application.DTO.RateDTO;

/// <summary>
/// Данные для создания нового курса
/// </summary>
public record CreateRateDto
{
    /// <summary>
    /// Значение курса
    /// </summary>
    public required decimal Rate { get; set; }
}