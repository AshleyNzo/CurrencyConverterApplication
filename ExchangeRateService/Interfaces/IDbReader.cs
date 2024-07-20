
namespace ExchangeRateService
{
    public interface IDbReader
    {
        IEnumerable<ExchangeRates> GetAllExchangeRates();
    }
}