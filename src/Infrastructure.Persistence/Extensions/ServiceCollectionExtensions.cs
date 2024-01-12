using Application.Interfaces.Repositories;
using Infrastructure.Persistence.DbContexts;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration,
        bool isLocalDev)
    {
        services.AddOptions<DatabaseSettings>()
            .BindConfiguration(DatabaseSettings.SectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var databaseSettings = configuration.GetSection(DatabaseSettings.SectionName).Get<DatabaseSettings>() ??
                               throw new Exception("Configuration was not found.");
        var connectionString = databaseSettings.ConnectionString;

        if (isLocalDev)
        {
            services.AddDbContext<CustomDbContext>(opt =>
                opt.UseSqlite(connectionString, b => b.MigrationsAssembly("WebApi")));
        }
        else
        {
            // ToDo: use prod DB
            throw new InvalidOperationException("Production DB not yet set.");
        }

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IVehicleRepository, VehicleRepository>();

        return services;
    }
}