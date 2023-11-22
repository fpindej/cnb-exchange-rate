using ExchangeRate.CNB.Client.Configuration;
using ExchangeRate.CNB.Client.Dtos;
using ExchangeRate.CNB.Client.Exceptions;
using ExchangeRate.CNB.Client.Services;
using ExchangeRate.Common;
using ExchangeRate.Common.Exceptions;
using ExchangeRate.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ExchangeRate.CNB.Client;

public class ExchangeRateProvider : IExchangeRateProvider
{
    private readonly IExchangeRateService _exchangeRateService;

    private readonly ILogger<ExchangeRateProvider> _logger;

    private readonly string _defaultCurrency;

    public ExchangeRateProvider(IExchangeRateService exchangeRateService, ILogger<ExchangeRateProvider> logger,
        IOptionsSnapshot<CNBConfiguration> cnbConfiguration)
    {
        _exchangeRateService = exchangeRateService;
        _logger = logger;
        _defaultCurrency = cnbConfiguration.Value.DefaultCurrency;
    }

    public async Task<IEnumerable<ExchangeRate.Domain.Entities.ExchangeRate>> GetExchangeRatesAsync()
    {
        var response = await _exchangeRateService.FetchDataAsync();

        if (response is null)
            throw new HttpRequestException("Http response is null or empty");

        var content = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrWhiteSpace(content))
            throw new EmptyResultSetException("No content available for CNB exchange rate request");

        var parsedContent = ParseExchangeRateXml(content);

        return FilterExchangeRates(parsedContent, _defaultCurrency);
    }
    
    private static IEnumerable<ExchangeRate.Domain.Entities.ExchangeRate> FilterExchangeRates(ExchangeRateDto data,
        string defaultTargetCurrency)
    {
        if (data?.Tables.Rows is null)
            throw new EmptyResultSetException("Data cannot be empty");

        var filter = data.Tables.Rows.Where(w => CommonConstants.Currencies.Select(s => s.Code).Contains(w.Code));
        return filter.Select(f =>
            new ExchangeRate.Domain.Entities.ExchangeRate(new Currency(f.Code), new Currency(defaultTargetCurrency), GetRate(f)));
    }

    private static decimal GetRate(RowDto f) => f.Rate / f.Amount;

    private ExchangeRateDto ParseExchangeRateXml(string content)
    {
        try
        {
            return content.FromXml<ExchangeRateDto>();
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, e.Message);
            throw new XmlParsingException("Content from CNB xml request has invalid format");
        }
    }
}