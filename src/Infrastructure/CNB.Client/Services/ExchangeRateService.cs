using ExchangeRate.Core.Entities;

namespace ExchangeRate.Infrastructure.CNBClient.Services;

public class ExchangeRateService
{
    /// <summary>
    /// Should return exchange rates among the specified currencies that are defined by the source. But only those defined
    /// by the source, do not return calculated exchange rates. E.g. if the source contains "CZK/USD" but not "USD/CZK",
    /// do not return exchange rate "USD/CZK" with value calculated as 1 / "CZK/USD". If the source does not provide
    /// some of the currencies, ignore them.
    /// </summary>
    public IEnumerable<Core.Entities.ExchangeRate> GetExchangeRates(IEnumerable<Currency> currencies)
    {
        return Enumerable.Empty<Core.Entities.ExchangeRate>();
    }
}
