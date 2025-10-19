using SWAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI.Infrastructure.StarshipChecks
{
    public class SpeedCheckHandler : StarshipCheckHandler
    {
        public override void Handle(Starship starship)
        {
            //if (int.TryParse(starship.max_atmosphering_speed, out int speed) && speed < 0)
            if (starship.max_atmosphering_speed == "n/a" || starship.max_atmosphering_speed == "unknown")
                throw new Exception($"Invalid speed for {starship.Name ?? "unknown"}");

            _nextHandler?.Handle(starship);
        }
    }
}
