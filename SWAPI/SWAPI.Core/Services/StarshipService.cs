using SWAPI.Core.Entities;
using SWAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI.Core.Services
{
    public class StarshipService
    {
        private readonly ISwapiClient _swapiClient;
        private readonly IStarshipRepository? _repo;

        public StarshipService(ISwapiClient swapiClient, IStarshipRepository? repo = null)
        {
            _swapiClient = swapiClient;
            _repo = repo;
        }
        public async Task<IEnumerable<Starship>> GetStarshipsAsync(CancellationToken cancellationToken = default)
        {
            var (items, _) = await _swapiClient.GetStarshipsPageAsync(null, cancellationToken);

            var result = items.Select(dto => new Starship
            {
                Id = dto.Id,
                Name = dto.Name,
                Model = dto.Model,
                Manufacturer = dto.Manufacturer,
                CostInCredits = dto.CostInCreditsNumeric?.ToString() ?? dto.CostDisplay
            });

            return result;
        }
        public async Task<Starship?> GetStarshipByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var dto = await _swapiClient.GetStarshipByIdAsync(id, cancellationToken);
            if (dto == null) return null;

            return new Starship
            {
                Id = dto.Id,
                Name = dto.Name,
                Model = dto.Model,
                Manufacturer = dto.Manufacturer,
                CostInCredits = dto.CostInCreditsNumeric?.ToString() ?? dto.CostDisplay
            };
        }
    }
}
