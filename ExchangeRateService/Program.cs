using ExchangeRateService;
using ExchangeRateService.Model;






ExchangeRateClientHandler client = new ExchangeRateClientHandler(new HttpClient());

await client.GetCurrencyRates();





