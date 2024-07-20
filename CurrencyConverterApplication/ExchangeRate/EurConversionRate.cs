using ExchangeRateService;
using ExchangeRateService.Model;

namespace CurrencyConverter
{
    public class EurConversionRate : ICurrencyExchangeRate
    {

        private readonly IExchangeRateClient exchangeRate;
        private IDbReader _reader; 

        private const string currencyCode = "EUR"; 

        private Rates? currencyRates { get; set; }


        public EurConversionRate(IExchangeRateClient exchange,IDbReader reader)
        {
            
            this.exchangeRate = exchange;
            _reader = reader;
        }

        public  async Task<double> GetConverstionRate()
        {

            var exchangeRates = _reader.GetAllExchangeRates().Select(t => new { t.CurrencyCode, t.CurrencyRate }).ToDictionary(t => t.CurrencyCode, t => t.CurrencyRate);

            var eur = exchangeRates[currencyCode];  

            //currencyRates = await exchangeRate.GetCurrencyRates();

            return (double)eur; 
        }

        public async Task<double> ConvertCurrency(string originalCurrency)
        {
            currencyRates = await exchangeRate.GetCurrencyRates();

            return ConvertToTwoDecimalPlace(currencyRates.EUR,Convert.ToDouble(originalCurrency));
        }

        private double ConvertToTwoDecimalPlace(double conversionRate, double baseCurrency)
        {
          return  Math.Round(conversionRate * baseCurrency, 2);
        }
    }
}
