using SWAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI.Core.Interfaces
{
    public interface IStarshipRepository
    {
        Task<IEnumerable<Starship>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Starship> GetStarshipByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddAsync (Starship starship, CancellationToken cancellationToken = default);
        Task UpdateAsync(Starship starship, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
