using SWAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI.Infrastructure.StarshipChecks
{
    public abstract class StarshipCheckHandler
    {
        protected StarshipCheckHandler? _nextHandler;

        public void SetNext(StarshipCheckHandler next)
        {
            _nextHandler = next;
        }

        public abstract void Handle(Starship starship);
    }
}
