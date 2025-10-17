using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI.Core.DTOs
{
    public class StarshipDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public decimal? CostInCreditsNumeric { get; set; }
        public string CostDisplay { get; set; } = string.Empty;
    }
}
