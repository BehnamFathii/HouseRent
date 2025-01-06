using HouseRent.Core.Domain.Homes.Entities;

namespace HouseRent.Core.Domain.Homes.Repositories;
public interface IHomeRepository
{
    Task<Home?> GetByIdAsync(long Id, CancellationToken cancellationToken = default);
    Task<Home?> GetGraphByIdAsync(long Id, CancellationToken cancellationToken = default);
}