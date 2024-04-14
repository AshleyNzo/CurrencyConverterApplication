using ExchangeRateService.Model;

namespace ExchangeRateService
{
    public interface IExchangeRateClient
    {
        Task<List<Rates>> GetCurrencyRates();
    }
}