using ExchangeRateService.Model;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security;

namespace ExchangeRateService;

public class ExchangeRateClientHandler
{
    //public IHttpClientFactory _clientFactory;
    public HttpClient client; 
    public CurrencyRates currencyRates;
    public ExchangeRateClientHandler(HttpClient client,CurrencyRates currencyRates) { 

        //_clientFactory = _client;
        this.currencyRates = currencyRates;
        this.client = client;
    
    }

    public async Task GetCurrencyRates() {

     
        var request = new HttpRequestMessage(HttpMethod.Get, "https://api.currencybeacon.com/v1/latest?base=GBP&api_key=Vqs7RqILy8UPsXw8HzI02u0XyomEONWy");

        
           
        HttpResponseMessage response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            currencyRates = await response.Content.ReadFromJsonAsync<CurrencyRates>();

        }
        else
        {
            Console.WriteLine($"There was an error getting the request of currency rates{response.ReasonPhrase}");

        }

        Console.WriteLine(currencyRates!.rates.ADA); 

        
        


    }


}
