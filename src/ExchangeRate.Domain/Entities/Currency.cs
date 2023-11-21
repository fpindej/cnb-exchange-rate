namespace ExchangeRate.Domain.Entities;

public sealed class Currency
{
    /// <summary>
    ///     Three-letter ISO 4217 code of the currency.
    /// </summary>
    private readonly string _code;
    
    public Currency(string code)
    {
        _code = code;
    }

    public override string ToString()
    {
        return _code;
    }
}