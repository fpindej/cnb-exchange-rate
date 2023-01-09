using System.Text.RegularExpressions;

namespace ExchangeRate.Core.Entities;

public sealed partial class Currency
{
    public Currency(string code)
    {
        if (!CurrencyCodeRegex().IsMatch(code))
            throw new ArgumentException("Invalid currency code", nameof(code));

        Code = code;
    }

    /// <summary>
    ///     Three-letter ISO 4217 code of the currency.
    /// </summary>
    private string Code { get; }

    public override string ToString() => Code;

    [GeneratedRegex("^[A-Z]{3}$")]
    private static partial Regex CurrencyCodeRegex();
}
