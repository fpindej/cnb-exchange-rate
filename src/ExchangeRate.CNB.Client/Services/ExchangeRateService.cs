using System.Net;
using ExchangeRate.CNB.Client.Configuration;
using Microsoft.Extensions.Options;

namespace ExchangeRate.CNB.Client.Services;

public class ExchangeRateService : IExchangeRateService
{
    private readonly string _exchangeRatesUrl;
    private readonly HttpClient _httpClient;

    public ExchangeRateService(HttpClient httpClient, IOptionsSnapshot<CNBConfiguration> cnbConfiguration)
    {
        _httpClient = httpClient;
        _exchangeRatesUrl = cnbConfiguration.Value.RequestUrl;
    }

    public async Task<HttpResponseMessage> FetchDataAsync()
    {
        var response = await _httpClient.GetAsync(_exchangeRatesUrl);

        if (IsResponseInvalid(response))
            throw new HttpRequestException($"Http request error: {response.StatusCode}");

        return response;
    }

    private static bool IsResponseInvalid(HttpResponseMessage resp)
        => resp.StatusCode is HttpStatusCode.InternalServerError
            or HttpStatusCode.BadRequest
            or HttpStatusCode.GatewayTimeout
            or HttpStatusCode.NotImplemented
            or HttpStatusCode.Forbidden
            or HttpStatusCode.NotFound
            or HttpStatusCode.BadGateway;
}