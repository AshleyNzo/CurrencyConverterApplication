namespace CurrencyConverter
{
    public interface ICurrencyExchangeRate
    {
        Task<double> GetConverstionRate();

        Task<double> ConvertCurrency(string originalCurrency);

        
    }
}