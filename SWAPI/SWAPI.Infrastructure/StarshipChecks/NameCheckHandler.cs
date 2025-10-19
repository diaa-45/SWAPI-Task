using SWAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI.Infrastructure.StarshipChecks
{
    public class NameCheckHandler : StarshipCheckHandler
    {
        public override void Handle(Starship starship)
        {
            if (string.IsNullOrWhiteSpace(starship.Name))
                throw new Exception("Starship name is missing.");

            _nextHandler?.Handle(starship);
        }
    }
}
