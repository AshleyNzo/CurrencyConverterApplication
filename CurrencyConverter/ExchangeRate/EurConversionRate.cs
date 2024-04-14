using ExchangeRateService;
using ExchangeRateService.Model;

namespace CurrencyConverter
{
    public class EurConversionRate : ICurrencyExchangeRate
    {

        private readonly IExchangeRateClient exchangeRate;

        private Rates? currencyRates { get; set; }


        public EurConversionRate(IExchangeRateClient exchange)
        {
            
            this.exchangeRate = exchange;
        }

        public  double GetConverstionRate()
        {
            var currencyRates = exchangeRate.GetCurrencyRates().Result.Rates;

            return 100;
                //currencyRates.EUR; 
        }



        public double ConvertCurrency(string originalCurrency)
        {
            currencyRates = exchangeRate.GetCurrencyRates().Result.Rates.FirstOrDefault();

            return ConvertToTwoDecimalPlace(currencyRates.EUR,Convert.ToDouble(originalCurrency));
        }

        private double ConvertToTwoDecimalPlace(double conversionRate, double baseCurrency)
        {
          return  Math.Round(conversionRate * baseCurrency, 2);
        }
    }
}
