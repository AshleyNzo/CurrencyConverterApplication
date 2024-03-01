
//GBP TO USD - 1 = 1.27
//GBP TO EUR - 1 = 1.15
//GBP TO YEN - 1 = 9.06
//GBP TO ANG - 1 = 1065.19


using CurrencyConverter;
using ExchangeRateService;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;





var services = new ServiceCollection();

services.AddScoped<IExchangeRateClient,ExchangeRateClientHandler>();
services.AddHttpClient<IExchangeRateClient, ExchangeRateClientHandler>(client =>

    client.BaseAddress = new Uri("https://api.currencybeacon.com/v1/latest")
) ;
services.AddScoped<ICurrencyExchangeRate, AoaConversionRate>();
var serviceProvider = services.BuildServiceProvider(new ServiceProviderOptions
{
    ValidateOnBuild = true
});



ICurrencyExchangeRate rateMapper;

var aoaMapper = serviceProvider.GetService<ICurrencyExchangeRate>();
CurrencySymbolGenerator symbolGenerator = new CurrencySymbolGenerator();





 string input = String.Empty;



     /*
     rateMapper = new UsConversionRate(new ExchangeRateClientHandler(new HttpClient()));
     symbolGenerator.SetRegionCurrencyTwoLetterValue("US");
     Console.WriteLine($"The conversion rate to USD, using the current exchange rate is: {symbolGenerator.GetCurrencySymbol()}{Math.Round(rateMapper.GetConverstionRate(), 2)}");
     symbolGenerator.SetRegionCurrencyTwoLetterValue("FR");
     rateMapper = new EurConversionRate(new ExchangeRateClientHandler(new HttpClient()));
     Console.WriteLine($"The conversion rate to EUR, using the current exchange rate is: {Math.Round(rateMapper.GetConverstionRate(), 2)}{symbolGenerator.GetCurrencySymbol()}");
     symbolGenerator.SetRegionCurrencyTwoLetterValue("CN");
     rateMapper = new YuanConversionRate(new ExchangeRateClientHandler(new HttpClient()));
     Console.WriteLine($"The conversion rate to YEN, using the current exchange rate is: {Math.Round(rateMapper.GetConverstionRate(), 2)}{symbolGenerator.GetCurrencySymbol()}");
     */

     symbolGenerator.SetRegionCurrencyTwoLetterValue("AO");
     Console.WriteLine($"The conversion rate to ANG, using the current exchange rate is: {Math.Round(aoaMapper.GetConverstionRate(), 2)}{symbolGenerator.GetCurrencySymbol()}");


    Console.WriteLine("Would you like to convert to a currency displayed above?: ");
    Console.Write("Options - Yes & No: ");
    int inputValue;
    input = Console.ReadLine()!.ToLower();

    bool success = ValidInput(input);
    while (!success)
    {
        Console.Write("Invalid input, please eneter yes or no: ");
        input = Console.ReadLine()!.ToLower();
        success = ValidInput(input);
    }
    if (input.ToLower() == "yes")
    {
        Console.WriteLine("Currency options  - USD,EUR,YEN,AOA");
        Console.Write("Select currency for conversion:");

        var secondInput = Console.ReadLine()!.ToLower();
        bool validCurrencyCode = ValidCurrencyInput(secondInput);
        while (!validCurrencyCode) 
        {
            Console.WriteLine("Currency code no recongised, please enter a valid code");
            Console.Write("Valid codes - USD,EUR,YEN,AOA:");
            secondInput = Console.ReadLine()!.ToLower();
            validCurrencyCode = ValidCurrencyInput(secondInput);

        }
        /*
        if (secondInput == "usd")
        {
            symbolGenerator.SetRegionCurrencyTwoLetterValue("US");
            Console.Write("Enter a amount to convert to USD:");
            var amount = Console.ReadLine();
            rateMapper = new UsConversionRate(new ExchangeRateClientHandler(new HttpClient()));
            double convertedAmount = Math.Round(Convert.ToDouble(amount) * rateMapper.GetConverstionRate(), 2);
            Console.WriteLine($"{symbolGenerator.GetCurrencySymbol()}{convertedAmount}");

        }
        if (secondInput == "eur")
         {
            symbolGenerator.SetRegionCurrencyTwoLetterValue("FR");
            Console.Write("Enter a amount to convert to EUR:");
            var amount = Console.ReadLine();
            rateMapper = new EurConversionRate(new ExchangeRateClientHandler(new HttpClient()));
            double convertedAmount = Math.Round(Convert.ToDouble(amount) * rateMapper.GetConverstionRate(), 2);
            Console.WriteLine($"{symbolGenerator.GetCurrencySymbol()}{convertedAmount}");

         }
         if (secondInput == "yuan")
         {
            symbolGenerator.SetRegionCurrencyTwoLetterValue("CN");
            Console.Write("Enter a amount to convert to YUAN:");
            var amount = Console.ReadLine();
            rateMapper = new YuanConversionRate(new ExchangeRateClientHandler(new HttpClient()));
            double convertedAmount = Math.Round(Convert.ToDouble(amount) * rateMapper.GetConverstionRate(), 2);
            Console.WriteLine($"{symbolGenerator.GetCurrencySymbol()}{convertedAmount}");

         }
         */
         if (secondInput == "aoa")
         {
            symbolGenerator.SetRegionCurrencyTwoLetterValue("AO");
            Console.Write("Enter a amount to convert to AOA:");
            var amount = Console.ReadLine();
            double convertedAmount = Math.Round(Convert.ToDouble(amount) * aoaMapper.GetConverstionRate(), 2);
            Console.WriteLine($"{symbolGenerator.GetCurrencySymbol()}{convertedAmount}");

         }


    }
    else if (input == "no")
    {
        Console.WriteLine("Thanks for using the currency converter! =)");
      
    }
    else
    {

        Console.WriteLine("Sorry input not recongised.");
    }

    bool ValidInput(string input) {

      return input.ToLower().Equals("yes") || input.ToLower().Equals("no");

    }
    
    bool ValidCurrencyInput(string input) {

        return input.ToLower().Equals("usd") || input.ToLower().Equals("eur") || input.ToLower().Equals("yen") || input.ToLower().Equals("aoa");

}

