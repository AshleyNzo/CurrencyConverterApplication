using ExchangeRateService.Model;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security;

namespace ExchangeRateService;

public class ExchangeRateClientHandler : IExchangeRateClient
{
    //public IHttpClientFactory _clientFactory;
    public HttpClient client;

    public CurrencyRates currencyRates { get; set; }

    public ExchangeRateClientHandler(HttpClient client) { 

        this.client = client;
    
    }

    public async Task<CurrencyRates> GetCurrencyRates() {

        try
        {
            currencyRates = await client.GetFromJsonAsync<CurrencyRates>("?base=GBP&api_key=Vqs7RqILy8UPsXw8HzI02u0XyomEONWy");
        }
        catch (Exception ex) 
        {

            Console.WriteLine($"There was an error getting the request of currency rates{ex.Message}");

        }

        return currencyRates;

    }


}
