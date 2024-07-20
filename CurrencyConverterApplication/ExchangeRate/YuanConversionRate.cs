using ExchangeRateService.Model;
using ExchangeRateService;


namespace CurrencyConverter
{
    public class YuanConversionRate : ICurrencyExchangeRate
    {
        
        private readonly IExchangeRateClient exchangeRate;
        private IDbReader _reader; 

        private Rates? currencyRates { get; set; }


        public YuanConversionRate(IExchangeRateClient exchangeRate, IDbReader reader)
        {
            this.exchangeRate = exchangeRate;
            _reader = reader;
        }

        public async Task<double> GetConverstionRate()
        {
            var exchangeRates = _reader.GetAllExchangeRates().ToList();

            var cny = exchangeRates.Where(x => x.CurrencyCode == "CNY").FirstOrDefault();

            //currencyRates = await exchangeRate.GetCurrencyRates();

            return (double)cny.CurrencyRate;
        }

        public async Task<double> ConvertCurrency(string originalCurrency)
        {
            currencyRates = await exchangeRate.GetCurrencyRates();

            return ConvertToTwoDecimalPlace(currencyRates.CNY, Convert.ToDouble(originalCurrency));
        }

        private double ConvertToTwoDecimalPlace(double conversionRate, double baseCurrency)
        {
            return Math.Round(conversionRate * baseCurrency, 2);
        }



    }
}
