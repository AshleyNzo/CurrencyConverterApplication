using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateService
{
    public class ExchangeRateClientHandler
    {
        private static HttpClient client = new()
        {
            BaseAddress = new Uri("currency-conversion-and-exchange-rates.p.rapidapi.com"),
            DefaultRequestHeaders.Add("X-RapidAPI-Key", "92bc709628mshc5f0a69d2d6e2acp149118jsne4520e86fd35"),
        };




        public static async Task GetCurrencyRates(HttpClient client) { 
        

        }


    }
}
