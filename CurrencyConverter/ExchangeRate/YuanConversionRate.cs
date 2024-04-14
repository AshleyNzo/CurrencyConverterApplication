using ExchangeRateService.Model;
using ExchangeRateService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class YuanConversionRate : ICurrencyExchangeRate
    {
        
        private readonly IExchangeRateClient exchangeRate;

        private Rates? currencyRates { get; set; }


        public YuanConversionRate(IExchangeRateClient exchangeRate)
        {
            this.exchangeRate = exchangeRate;
        }

        public double GetConverstionRate()
        {
            var currencyRates = exchangeRate.GetCurrencyRates().Result.Rates;

            return 100;//currencyRates.CNY;
        }

        public double ConvertCurrency(string originalCurrency)
        {
            currencyRates = exchangeRate.GetCurrencyRates().Result.Rates.FirstOrDefault();

            return ConvertToTwoDecimalPlace(currencyRates.CNY, Convert.ToDouble(originalCurrency));
        }

        private double ConvertToTwoDecimalPlace(double conversionRate, double baseCurrency)
        {
            return Math.Round(conversionRate * baseCurrency, 2);
        }



    }
}
