using SWAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI.Core.Services.Currency
{
    public class UsdConversionStrategy : ICurrencyConversionStrategy
    {
        public string CurrencySymbol => "$";

        public decimal Convert(decimal credits)
        {
            return credits * 1.2m;
        }
    }
}
