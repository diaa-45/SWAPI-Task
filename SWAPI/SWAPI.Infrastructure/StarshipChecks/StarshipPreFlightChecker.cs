using SWAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI.Infrastructure.StarshipChecks
{
    public class StarshipPreFlightChecker
    {
        private readonly StarshipCheckHandler _rootHandler;

        public StarshipPreFlightChecker()
        {
            var nameCheck = new NameCheckHandler();
            var manufacturerCheck = new ManufacturerCheckHandler();
            var speedCheck = new SpeedCheckHandler();

            nameCheck.SetNext(manufacturerCheck);
            manufacturerCheck.SetNext(speedCheck);

            _rootHandler = nameCheck;
        }
        public void RunChecks(Starship starship)
        {
            _rootHandler.Handle(starship);
        }
    }
}
