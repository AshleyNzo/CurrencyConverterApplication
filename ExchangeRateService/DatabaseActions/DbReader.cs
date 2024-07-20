using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;



namespace ExchangeRateService
{
    public class DbReader : IDbReader
    {
        private IConfiguration _configuration;


        public DbReader(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<ExchangeRates> GetAllExchangeRates()
        {

            var connectionString = _configuration.GetConnectionString("CurrencyRatesDB");
            SqlConnection connection = new SqlConnection(connectionString);

            string selectQuery = "SELECT * FROM CurrencyRates";

            IEnumerable<ExchangeRates> rates = connection.Query<ExchangeRates>(selectQuery);

            return rates;

        }
    }
}
