﻿
//GBP TO USD - 1 = 1.27
//GBP TO EUR - 1 = 1.15
//GBP TO YEN - 1 = 9.06
//GBP TO ANG - 1 = 1065.19


using CurrencyConverter;
using ExchangeRateService;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging; 





var services = new ServiceCollection();

IConfigurationRoot config = new ConfigurationBuilder().
    SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional:false)
    .Build();

services.AddTransient<IExchangeRateClient,ExchangeRateClientHandler>();
services.AddHttpClient("checking", client =>

 client.BaseAddress = new Uri(config.GetValue<string>("APIUrls:CurrencyBeacon"))
) ;

services.AddKeyedScoped<ICurrencyExchangeRate,AoaConversionRate>("AoA");
services.AddKeyedScoped<ICurrencyExchangeRate, YuanConversionRate>("Yuan");
services.AddKeyedScoped<ICurrencyExchangeRate, EurConversionRate>("Eur");
services.AddKeyedScoped<ICurrencyExchangeRate, UsConversionRate>("Us");
services.AddSingleton<IConfiguration>(config);

var serviceProvider = services.BuildServiceProvider(new ServiceProviderOptions
{
    ValidateOnBuild = true
});

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = factory.CreateLogger<Program>();
logger.LogInformation("Just testing out the loggin functionality where do you go?"); 


var aoaMapper = serviceProvider.GetRequiredKeyedService<ICurrencyExchangeRate>("AoA"); 
var yuanMapper = serviceProvider.GetRequiredKeyedService<ICurrencyExchangeRate>("Yuan");
var eurMapper = serviceProvider.GetRequiredKeyedService<ICurrencyExchangeRate>("Eur");
var usMapper = serviceProvider.GetRequiredKeyedService<ICurrencyExchangeRate>("Us");

CurrencySymbolGenerator symbolGenerator = new CurrencySymbolGenerator();





 string input = String.Empty;




     symbolGenerator.SetRegionCurrencyTwoLetterValue("US");
     Console.WriteLine($"The conversion rate to USD, using the current exchange rate is: {symbolGenerator.GetCurrencySymbol()}{Math.Round(usMapper.GetConverstionRate(), 2)}");
     symbolGenerator.SetRegionCurrencyTwoLetterValue("FR");
     Console.WriteLine($"The conversion rate to EUR, using the current exchange rate is: {Math.Round(eurMapper.GetConverstionRate(), 2)}{symbolGenerator.GetCurrencySymbol()}");
     symbolGenerator.SetRegionCurrencyTwoLetterValue("CN");
     Console.WriteLine($"The conversion rate to YEN, using the current exchange rate is: {Math.Round(yuanMapper.GetConverstionRate(), 2)}{symbolGenerator.GetCurrencySymbol()}");    
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
        if (secondInput == "usd")
        {
            symbolGenerator.SetRegionCurrencyTwoLetterValue("US");
            Console.Write("Enter a amount to convert to USD:");
            var amount = Console.ReadLine();
            double convertedAmount = Math.Round(Convert.ToDouble(amount) * usMapper.GetConverstionRate(), 2);
            Console.WriteLine($"{symbolGenerator.GetCurrencySymbol()}{convertedAmount}");

        }
        if (secondInput == "eur")
         {
            symbolGenerator.SetRegionCurrencyTwoLetterValue("FR");
            Console.Write("Enter a amount to convert to EUR:");
            var amount = Console.ReadLine();
            double convertedAmount = Math.Round(Convert.ToDouble(amount) * eurMapper.GetConverstionRate(), 2);
            Console.WriteLine($"{symbolGenerator.GetCurrencySymbol()}{convertedAmount}");

         }
         if (secondInput == "yuan")
         {
            symbolGenerator.SetRegionCurrencyTwoLetterValue("CN");
            Console.Write("Enter a amount to convert to YUAN:");
            var amount = Console.ReadLine();
            double convertedAmount = Math.Round(Convert.ToDouble(amount) * yuanMapper.GetConverstionRate(), 2);
            Console.WriteLine($"{symbolGenerator.GetCurrencySymbol()}{convertedAmount}");

         }
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


