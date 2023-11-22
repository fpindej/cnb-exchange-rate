namespace ExchangeRate.CNB.Domain;

/// <summary>
///     Provider for Exchange Rate from CNB
/// </summary>
public interface IExchangeRateProvider
{
    /// <summary>
    ///     Gets the Exchange Rate data from a data source
    /// </summary>
    /// <returns>ExchangeRate</returns>
    Task<IEnumerable<ExchangeRate.Domain.Entities.ExchangeRate>> GetExchangeRatesAsync();
}