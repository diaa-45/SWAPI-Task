using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string? message = null) : base(message ?? "Resource was not found.")
        {
        }
    }
}
