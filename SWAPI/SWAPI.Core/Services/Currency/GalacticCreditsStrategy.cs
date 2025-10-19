using SWAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI.Core.Services.Currency
{
    public class GalacticCreditsStrategy : ICurrencyConversionStrategy
    {
        public string CurrencySymbol => "GC";

        public decimal Convert(decimal credits) => credits;
    }
}
