
namespace ExchangeRateService
{
    public interface ICurrencyConversionRates
    {
        Task<List<ExchangeRates>> getAllCurrencyRates();
    }
}