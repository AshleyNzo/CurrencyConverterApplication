using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateService.Model
{

    public class CurrencyRates
    {
        public Rates? Rates { get; set; }
        public DateTime Date { get; set; }
        public string? Base { get; set; }
    }
    
}
