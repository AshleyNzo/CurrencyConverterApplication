using ExchangeRateService;
using ExchangeRateService.Model;


namespace CurrencyConverter
{
    public class AoaConversionRate : ICurrencyExchangeRate
    {

        private readonly IExchangeRateClient exchangeRate;
        private readonly IDbReader _reader;

        private const string currencyCode = "AOA";

        private Rates? currencyRates { get; set; }


        public AoaConversionRate(IExchangeRateClient exchange,IDbReader reader)
        {
            
            this.exchangeRate = exchange;
            _reader = reader;
        }

        public async Task<double> GetConverstionRate()
        {
            var exchangeRates = _reader.GetAllExchangeRates().Select(t => new { t.CurrencyCode, t.CurrencyRate }).ToDictionary(t => t.CurrencyCode, t => t.CurrencyRate);

            var aoa = exchangeRates[currencyCode];

            
            /*
            currencyRates = await exchangeRate.GetCurrencyRates();

            var h = currencyRates.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(currencyRates, null));

            var tr = h.Any();
            */

            return (double)aoa; 
        }



        public async Task<double> ConvertCurrency(string originalCurrency)
        {
            currencyRates =await exchangeRate.GetCurrencyRates();

            return ConvertToTwoDecimalPlace(currencyRates.AOA,Convert.ToDouble(originalCurrency));
        }

        private double ConvertToTwoDecimalPlace(double conversionRate, double baseCurrency)
        {
          return  Math.Round(conversionRate * baseCurrency, 2);
        }
    }
}
