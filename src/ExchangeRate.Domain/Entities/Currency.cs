namespace ExchangeRate.Domain.Entities;

public sealed class Currency
{
    /// <summary>
    ///     Three-letter ISO 4217 code of the currency.
    /// </summary>
    public string Code { get; }
    
    public Currency(string code)
    {
        Code = code;
    }

    public override string ToString()
    {
        return Code;
    }
}