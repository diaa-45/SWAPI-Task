using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI.Core.Interfaces
{
    public interface ICurrencyConversionStrategy
    {
        decimal Convert(decimal credits);
        string CurrencySymbol { get; }
    }
}
