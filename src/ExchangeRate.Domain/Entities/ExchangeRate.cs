namespace ExchangeRate.Domain.Entities;

public class ExchangeRate
{
    private readonly Currency _sourceCurrency;

    private readonly Currency _targetCurrency;

    private readonly decimal _value;
    
    public ExchangeRate(Currency sourceCurrency, Currency targetCurrency, decimal value)
    {
        _sourceCurrency = sourceCurrency;
        _targetCurrency = targetCurrency;
        _value = value;
    }
    
    public override string ToString() => $"{_sourceCurrency}/{_targetCurrency}={_value}";
}