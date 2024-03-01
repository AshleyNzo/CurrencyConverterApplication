using ExchangeRateService.Model;

namespace ExchangeRateService
{
    public interface IExchangeRateClient
    {
        Task<CurrencyRates> GetCurrencyRates();
    }
}