using Microsoft.Extensions.DependencyInjection;

namespace ExchangeRate.CNB.Client;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCnbClient(this IServiceCollection services)
    {
        services.AddOptions<CNBConfiguration>()
            .BindConfiguration(CNBConfiguration.SectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services;
    }
}