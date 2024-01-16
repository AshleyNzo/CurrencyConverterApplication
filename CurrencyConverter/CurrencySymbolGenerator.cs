using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public  class CurrencySymbolGenerator
    {
        private RegionInfo ?_region;
        public CurrencySymbolGenerator() { 
        

            Console.OutputEncoding = System.Text.Encoding.UTF8;
         
        }


        public void SetRegionCurrencyTwoLetterValue(string code) { 
        
            _region = new RegionInfo(code);
        }

        public string GetCurrencySymbol() {

            return _region.CurrencySymbol;
         
        }
    }
}
