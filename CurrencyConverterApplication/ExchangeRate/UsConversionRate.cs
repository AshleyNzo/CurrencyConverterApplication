using ExchangeRateService;
using ExchangeRateService.Model;

namespace CurrencyConverter
{
    public class UsConversionRate : ICurrencyExchangeRate 
    {

        private readonly IExchangeRateClient exchangeRate;
        private IDbReader _reader;

        private Rates? currencyRates { get; set; }


        public UsConversionRate(IExchangeRateClient exchange,IDbReader reader)
        {
            
            this.exchangeRate = exchange;
             _reader = reader;
        }

        public async Task<double> GetConverstionRate()
        {
            var exchangeRates = _reader.GetAllExchangeRates().ToList();

            var usd = exchangeRates.Where(x => x.CurrencyCode == "USD").FirstOrDefault();

            //currencyRates = await exchangeRate.GetCurrencyRates();

            return (double)usd.CurrencyRate; 
        }

        public async Task<double> ConvertCurrency(string originalCurrency)
        {
            currencyRates = await exchangeRate.GetCurrencyRates();

            return ConvertToTwoDecimalPlace(currencyRates.USD,Convert.ToDouble(originalCurrency));
        }

        private double ConvertToTwoDecimalPlace(double conversionRate, double baseCurrency)
        {
          return  Math.Round(conversionRate * baseCurrency, 2);
        }
    }
}
