using ExchangeRateService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CurrencyConverter
{
    public static class ServiceCollectionExtension
    {
       
        public static void AddMyClassSetup(this IServiceCollection services) {

            IConfigurationRoot config = new ConfigurationBuilder().
            SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false)
           .Build();

            services.AddTransient<IExchangeRateClient, ExchangeRateClientHandler>();
            services.AddHttpClient("checking", client =>

            client.BaseAddress = new Uri(config.GetValue<string>("APIUrls:CurrencyBeacon"))
            );
            services.AddSingleton<IConfiguration>(config);
            services.AddKeyedScoped<ICurrencyExchangeRate, AoaConversionRate>("AoA");
            services.AddKeyedScoped<ICurrencyExchangeRate, YuanConversionRate>("Yuan");
            services.AddKeyedScoped<ICurrencyExchangeRate, EurConversionRate>("Eur");
            services.AddKeyedScoped<ICurrencyExchangeRate, UsConversionRate>("Us");
            services.AddSingleton<IDbReader, DbReader>();
        }
       

    }
}
