namespace CurrencyConverter
{
    public interface ICurrencyExchangeRate
    {
        double GetConverstionRate();

        double ConvertCurrency(string originalCurrency);

        
    }
}