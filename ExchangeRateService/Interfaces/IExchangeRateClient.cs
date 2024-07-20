using ExchangeRateService.Model;

namespace ExchangeRateService
{
    public interface IExchangeRateClient
    {
        Task<Rates> GetCurrencyRates();
    }
}