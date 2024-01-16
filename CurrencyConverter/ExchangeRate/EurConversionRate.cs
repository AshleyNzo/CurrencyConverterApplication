using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class EurConversionRate : CurrencyExchangeRate
    {
        private double GBPTOEUR { get; } = 1.15003;
        public override double GetConverstionRate()
        {
            return GBPTOEUR;
        }
    }
}
