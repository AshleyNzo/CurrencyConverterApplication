using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class AnConversionRate : CurrencyExchangeRate
    {
        private double GBPTOANG { get; } = 1064.96000;
        public override double GetConverstionRate()
        {
            return GBPTOANG;
        }
    }
}
