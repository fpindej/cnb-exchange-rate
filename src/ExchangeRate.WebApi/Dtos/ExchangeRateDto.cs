using ExchangeRate.Domain.Entities;

namespace ExchangeRate.WebApi.Dtos;

public class ExchangeRateDto
{
    public Currency SourceCurrengy { get; set; }
    
    public Currency TargetCurrency { get; set; }
    
    public decimal Amount { get; set; }
}