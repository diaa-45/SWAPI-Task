using SWAPI.Core.DTOs;

namespace SWAPI.Core.Interfaces
{
    public interface ISwapiClient
    {
        Task<(IEnumerable<StarshipDto> Items, string? NextPageUrl)> GetStarshipsPageAsync(string? pageUrl = null, CancellationToken cancellationToken = default);

        Task<StarshipDto?> GetStarshipByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
