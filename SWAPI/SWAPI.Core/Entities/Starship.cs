using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI.Core.Entities
{
    public class Starship
    {
        public string Name { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string CostInCredits { get; set; } = string.Empty;
        public string Length { get; set; } = string.Empty;
        public string Crew { get; set; } = string.Empty;
        public string max_atmosphering_speed { get; set; } = string.Empty;
        public string Passengers { get; set; } = string.Empty;
        public string StarshipClass { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
    }
}
