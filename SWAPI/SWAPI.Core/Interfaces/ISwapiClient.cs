using SWAPI.Core.DTOs;
using SWAPI.Core.Entities;

namespace SWAPI.Core.Interfaces
{
    public interface ISwapiClient
    {
        Task<(IEnumerable<Starship> ValidShips, IEnumerable<(string Name, string Reason)> FailedShips, string? NextPageUrl)>
                GetStarshipsPageAsync(string? pageUrl = null, CancellationToken cancellationToken = default);

        Task<Starship?> GetStarshipByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
