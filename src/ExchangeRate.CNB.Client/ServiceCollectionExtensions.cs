using System.Net;
using ExchangeRate.CNB.Client.Services;
using ExchangeRate.CNB.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace ExchangeRate.CNB.Client;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCnbClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<CNBConfiguration>()
            .BindConfiguration(CNBConfiguration.SectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var config = configuration.GetSection(CNBConfiguration.SectionName).Get<CNBConfiguration>() ??
                     throw new Exception("Configuration was not found.");

        services.AddHttpClient<IExchangeRateService, ExchangeRateService>(opt => { opt.BaseAddress = config.BaseUrl; })
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .AddPolicyHandler(GetRetryPolicy(config.RetryCount));
        
        return services;
    }
    
    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(int retryCount)
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode is HttpStatusCode.NotFound)
            .WaitAndRetryAsync(retryCount, retryAttempt => TimeSpan.FromSeconds(2));
    }
}