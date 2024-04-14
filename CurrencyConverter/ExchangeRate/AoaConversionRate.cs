using ExchangeRateService;
using ExchangeRateService.Model;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter
{
    public class AoaConversionRate : ICurrencyExchangeRate
    {

        private readonly IExchangeRateClient exchangeRate;

        private Rates? currencyRates { get; set; }


        public AoaConversionRate(IExchangeRateClient exchange)
        {
            
            this.exchangeRate = exchange;
        }

        public  double GetConverstionRate()
        {
            var currencyRates = exchangeRate.GetCurrencyRates().Result;

            return 100;
            //return currencyRates.AOA; 
        }



        public double ConvertCurrency(string originalCurrency)
        {
            currencyRates = exchangeRate.GetCurrencyRates().Result;

            return ConvertToTwoDecimalPlace(currencyRates.AOA,Convert.ToDouble(originalCurrency));
        }

        private double ConvertToTwoDecimalPlace(double conversionRate, double baseCurrency)
        {
          return  Math.Round(conversionRate * baseCurrency, 2);
        }
    }
}
