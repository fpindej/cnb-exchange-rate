using ExchangeRate.Domain.Entities;

namespace ExchangeRate.WebApi.Dtos;

internal class ExchangeRateDto
{
    public Currency SourceCurrengy { get; set; }
    
    public Currency TargetCurrency { get; set; }
    
    public decimal Amount { get; set; }
}