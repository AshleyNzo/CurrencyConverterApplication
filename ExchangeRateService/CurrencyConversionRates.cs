
using Dapper;
using ExchangeRateService.Model;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace ExchangeRateService
{
    public class CurrencyConversionRates : ICurrencyConversionRates
    {

        private IExchangeRateClient _exchange;

        private Rates? currencyRates { get; set; }
        public CurrencyConversionRates(IExchangeRateClient exchange)
        {
            _exchange = exchange;

        }

        public async Task<List<ExchangeRates>> getAllCurrencyRates()
        {

            List<ExchangeRates> myList = new List<ExchangeRates>();

            currencyRates = await _exchange.GetCurrencyRates();


            var h = currencyRates.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
               .ToDictionary(prop => prop.Name, prop => prop.GetValue(currencyRates, null));


            foreach (var i in h)
            {

                myList.Add(new ExchangeRates()
                {

                    CurrencyCode = i.Key,
                    CurrencyRate = (float)i.Value

                });
            }

            return myList;

        }

    }
}
