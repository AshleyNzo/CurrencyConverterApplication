using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace ExchangeRateService
{
    public class DbWriter : IDbWriter
    {
        private ICurrencyConversionRates _currencyConversionRates;
        private IConfiguration _configuration;

        public DbWriter(ICurrencyConversionRates conversionRates, IConfiguration configuration)
        {

            _currencyConversionRates = conversionRates;
            _configuration = configuration;
        }

        public async Task AddTodb()
        {

            var myList = await _currencyConversionRates.getAllCurrencyRates();

            var connectionString = _configuration.GetConnectionString("CurrencyRatesDB");
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Execute("TRUNCATE TABLE CurrencyRates");

            foreach (var item in myList)
            {
                string processQuery = "INSERT INTO CurrencyRates VALUES (@CurrencyCode, @CurrencyRate)";
                connection.Execute(processQuery, item);

            }
        }

    }
}
