using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Common;

public static class CommonConstants
{
    public static readonly IEnumerable<Currency> Currencies = new List<Currency>
    {
        new("USD"),
        new("EUR"),
        new("CZK"),
        new("JPY"),
        new("KES"),
        new("RUB"),
        new("THB"),
        new("TRY"),
        new("XYZ")
    };
}