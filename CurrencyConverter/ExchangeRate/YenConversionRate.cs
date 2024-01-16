using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class YenConversionRate : CurrencyExchangeRate
    {
        private double GBPTOYEN { get; } = 9.04795;
        public override double GetConverstionRate()
        {
            return GBPTOYEN;
        }
    }
}
