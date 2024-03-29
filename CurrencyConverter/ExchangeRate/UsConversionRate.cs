﻿using ExchangeRateService;
using ExchangeRateService.Model;

namespace CurrencyConverter
{
    public class UsConversionRate : ICurrencyExchangeRate 
    {

        private readonly IExchangeRateClient exchangeRate;

        private Rates? currencyRates { get; set; }


        public UsConversionRate(IExchangeRateClient exchange)
        {
            
            this.exchangeRate = exchange;
        }

        public  double GetConverstionRate()
        {
            var currencyRates = exchangeRate.GetCurrencyRates().Result.rates;

            return currencyRates.AOA; 
        }



        public double ConvertCurrency(string originalCurrency)
        {
            currencyRates = exchangeRate.GetCurrencyRates().Result.rates;

            return ConvertToTwoDecimalPlace(currencyRates.AOA,Convert.ToDouble(originalCurrency));
        }

        private double ConvertToTwoDecimalPlace(double conversionRate, double baseCurrency)
        {
          return  Math.Round(conversionRate * baseCurrency, 2);
        }
    }
}
