using ExchangeRateService;
using ExchangeRateService.Model;






ExchangeRateClientHandler client = new ExchangeRateClientHandler(new HttpClient(),new CurrencyRates());

await client.GetCurrencyRates();





