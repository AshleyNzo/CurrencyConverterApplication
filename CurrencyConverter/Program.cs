
//GBP TO USD - 1 = 1.27
//GBP TO EUR - 1 = 1.15
//GBP TO YEN - 1 = 9.06
//GBP TO ANG - 1 = 1065.19


using CurrencyConverter;
using System.Runtime.CompilerServices;




CurrencyExchangeRate rateMapper;
CurrencySymbolGenerator symbolGenerator = new CurrencySymbolGenerator();





 string input = String.Empty;



   
     rateMapper = new UsConversionRate();
     symbolGenerator.SetRegionCurrencyTwoLetterValue("US");
     Console.WriteLine($"The conversion rate to USD, using the current exchange rate is: {symbolGenerator.GetCurrencySymbol()}{Math.Round(rateMapper.GetConverstionRate(), 2)}");
     symbolGenerator.SetRegionCurrencyTwoLetterValue("FR");
     rateMapper = new EurConversionRate();
     Console.WriteLine($"The conversion rate to EUR, using the current exchange rate is: {Math.Round(rateMapper.GetConverstionRate(), 2)}{symbolGenerator.GetCurrencySymbol()}");
     symbolGenerator.SetRegionCurrencyTwoLetterValue("CN");
     rateMapper = new YenConversionRate();
     Console.WriteLine($"The conversion rate to YEN, using the current exchange rate is: {Math.Round(rateMapper.GetConverstionRate(), 2)}{symbolGenerator.GetCurrencySymbol()}");
     symbolGenerator.SetRegionCurrencyTwoLetterValue("AO");
     rateMapper = new AnConversionRate();
     Console.WriteLine($"The conversion rate to ANG, using the current exchange rate is: {Math.Round(rateMapper.GetConverstionRate(), 2)}{symbolGenerator.GetCurrencySymbol()}");


    Console.WriteLine("Would you like to convert to a currency displayed above?: ");
    Console.Write("Following optionsare Yes & No: ");
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
        Console.Write("Select currency for conversion:  ");
        var secondInput = Console.ReadLine();
        if (secondInput.ToLower() == "usd")
        {
            symbolGenerator.SetRegionCurrencyTwoLetterValue("US");
            Console.Write("Enter a amount to convert to USD: ");
            var amount = Console.ReadLine();
            rateMapper = new UsConversionRate();
            double convertedAmount = Math.Round(Convert.ToDouble(amount) * rateMapper.GetConverstionRate(), 2);
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