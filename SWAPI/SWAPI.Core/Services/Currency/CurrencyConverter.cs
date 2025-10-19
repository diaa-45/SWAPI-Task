using SWAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI.Core.Services.Currency
{
    public class CurrencyConverter
    {
        private readonly ICurrencyConversionStrategy _strategy;

        public CurrencyConverter(ICurrencyConversionStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal Convert(decimal credits)
        {
            return _strategy.Convert(credits);
        }

        public string Symbol => _strategy.CurrencySymbol;
    }
}
