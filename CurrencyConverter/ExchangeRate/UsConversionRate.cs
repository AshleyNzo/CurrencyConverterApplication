using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class UsConversionRate : CurrencyExchangeRate
    {
        private double GBPTOUSD { get; } = 1.27455;
        public UsConversionRate() { 
        
        }
        public override double GetConverstionRate()
        {
            return GBPTOUSD;
        }

    
    }
}
