using ExchangeRateService.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;


namespace ExchangeRateService;

public class ExchangeRateClientHandler : IExchangeRateClient
{
    private IHttpClientFactory _clientFactory;
    private IConfiguration _configuration;
    private ILogger<ExchangeRateClientHandler> _logger;


    public CurrencyRates currencyRates { get; set; }

    public ExchangeRateClientHandler(IHttpClientFactory client, IConfiguration configuration
        , ILogger<ExchangeRateClientHandler> logger) { 

        _clientFactory = client;
        _configuration = configuration;
        _logger = logger; 
    }

    public async Task<Rates> GetCurrencyRates() {


        var apiKey = _configuration.GetValue<string>("Keys:APIKey");
        try
        {
            var client = _clientFactory.CreateClient("checking");
            currencyRates = await client?.GetFromJsonAsync<CurrencyRates>($"?base=GBP&api_key={apiKey}");
        }
        catch (Exception ex) 
        {

           _logger.LogInformation($"There was an error getting the request of currency rates{ex.Message}");

        }

        
        return currencyRates.Rates;

    }


}
