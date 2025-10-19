using SWAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI.Infrastructure.StarshipChecks
{
    public class ManufacturerCheckHandler : StarshipCheckHandler
    {
        public override void Handle(Starship starship)
        {
            if (string.IsNullOrWhiteSpace(starship.Manufacturer))
                throw new Exception($"Manufacturer missing for {starship.Name}");

            _nextHandler?.Handle(starship);
        }
    }
}
