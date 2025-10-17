using SWAPI.Core.DTOs;
using SWAPI.Core.Entities;
using SWAPI.Core.Exceptions;
using SWAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SWAPI.Infrastructure.Clients
{
    public class SwapiClient: ISwapiClient
    {
        private readonly HttpClient _httpClient;

        public SwapiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<(IEnumerable<StarshipDto> Items, string? NextPageUrl)> GetStarshipsPageAsync(string? pageUrl = null,CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetFromJsonAsync<SwapiResponse>("starships/");
            if (response == null || response.Results == null)
                throw new NotFoundException("No starships found.");
            Console.WriteLine(response.Count);
            return (response.Results, response.Next);
        }

        public async Task<StarshipDto?> GetStarshipByIdAsync(int id,CancellationToken cancellationToken = default)
        {
            var url = $"starships/{id}/";

            var starship = await _httpClient.GetFromJsonAsync<StarshipDto>(url, cancellationToken);

            if (starship == null)
                throw new NotFoundException("Starship not found.");

            return new StarshipDto
            {
                Name = starship.Name,
                Model = starship.Model,
                Manufacturer = starship.Manufacturer,
                Crew = starship.Crew
            };
        }

        public class SwapiResponse
        {
            public int Count { get; set; }
            public string? Next { get; set; }
            public string? Previous { get; set; }
            public List<StarshipDto>? Results { get; set; }
        }
    }
}
