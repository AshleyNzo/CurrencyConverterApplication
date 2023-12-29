// See https://aka.ms/new-console-template for more information



//GBP TO USD - 1 = 1.27
//GBP TO EUR - 1 = 1.15
//GBP TO YEN - 1 = 9.06
//GBP TO ANG - 1 = 1065.19


using System.Globalization;
using System.Runtime.InteropServices;

var GBPTOUSD = 1.27455;
var GBPTOEUR = 1.15003;
var GBPTOYEN = 9.04795;
var GBPTOANG = 1064.96000;

RegionInfo usRegion = new RegionInfo("US");
RegionInfo aoRegion = new RegionInfo("AO");
RegionInfo eurRegion = new RegionInfo("IT");
RegionInfo yenRegion = new RegionInfo("CN");
CultureInfo euroCI = new CultureInfo("de-DE");

Console.OutputEncoding = System.Text.Encoding.UTF8;

bool running = true;
 string input = String.Empty;

while (running)
{
   
    if (input.Length < 1)
    {
        Console.WriteLine($"The conversion rate to USD, using the current exchange rate is: {usRegion.CurrencySymbol}{Math.Round(GBPTOUSD, 2)}");
        Console.WriteLine($"The conversion rate to EUR, using the current exchange rate is: {Math.Round(GBPTOEUR, 2)}{eurRegion.CurrencySymbol}");
        Console.WriteLine($"The conversion rate to YEN, using the current exchange rate is: {Math.Round(GBPTOYEN, 2)}{yenRegion.CurrencySymbol}");
        Console.WriteLine($"The conversion rate to ANG, using the current exchange rate is: {Math.Round(GBPTOANG, 2)}{aoRegion.CurrencySymbol}");
    }
    
    Console.WriteLine("Would you like to convert to a currency displayed above?: ");
    Console.Write("Following options Yes,No: ");
    input = Console.ReadLine();
    if (input == "Yes")
    {
        Console.Write("Selecta currency for conversion:  ");
        var secondInput = Console.ReadLine();
        if (secondInput == "USD")
        {
            Console.Write("Enter a amount to convert to USD: ");
            var amount = Console.ReadLine(); ;
            Console.WriteLine(Math.Round(Convert.ToDouble(amount) * GBPTOUSD, 2));

        }
    }
    else if (input == "No")
    {
        Console.WriteLine("Thanks for using the currency converter! =)");
        running = false; 
    }
    else
    {

        Console.WriteLine("Sorry input not recongised.");
    }
}