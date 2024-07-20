
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace ExchangeRateService;

class Program
{
    public static async Task Main(string[] args)
    {


        
        var services = new ServiceCollection();



        IConfigurationRoot config = new ConfigurationBuilder().
        SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

        

        services.AddSingleton<IConfiguration>(config);
        services.AddTransient<IExchangeRateClient, ExchangeRateClientHandler>();
        services.AddSingleton<ICurrencyConversionRates, CurrencyConversionRates>();
        services.AddSingleton<CurrencyConversionRates>();

        services.AddHttpClient("checking", client =>
         client.BaseAddress = new Uri(config.GetValue<string>("APIUrls:CurrencyBeacon"))
        );
        services.AddSingleton<DbReader>();
        services.AddSingleton<DbWriter>();
        
        var serviceProvider = services.BuildServiceProvider();

        var dbWriter = serviceProvider.GetService<DbWriter>();



        Console.WriteLine("Requesting up to date currency conversion rates, please wait.......");
        if (dbWriter is not null)
        {
            await dbWriter.AddTodb();
        }
        Console.WriteLine("Updated to latest currency conversion rates");

    }

}

