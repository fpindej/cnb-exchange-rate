namespace ExchangeRate.Domain.Entities;

public class ExchangeRate
{
    public Currency SourceCurrency { get; }

    public Currency TargetCurrency { get; }

    public decimal Amount { get; }
    
    public ExchangeRate(Currency sourceCurrency, Currency targetCurrency, decimal amount)
    {
        SourceCurrency = sourceCurrency;
        TargetCurrency = targetCurrency;
        Amount = amount;
    }
}