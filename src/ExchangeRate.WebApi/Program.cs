using Serilog;
using LoggerConfigurationExtensions = ExchangeRate.WebApi.Extensions.LoggerConfigurationExtensions;

namespace ExchangeRate.WebApi;

public class Program
{
    public static int Main()
    {
        const string appName = "Exchange Rate API";
        LoggerConfigurationExtensions.SetupLoggerConfiguration();
        
        try
        {
            Log.Information("Starting web host {AppName}", appName);
            CreateHostBuilder().Build().Run();
            Log.Information("Ending web host {AppName}", appName);
            return 0;
        }
        catch (Exception e) when (e is not HostAbortedException)
        {
            Log.Fatal(e, "Host terminated unexpectedly {AppName}", appName);
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
    
    private static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .UseSerilog(Log.Logger, true)
            .ConfigureAppConfiguration((_, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                config.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);
            })
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}