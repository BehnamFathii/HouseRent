using HouseRent.Core.Domain.Homes.Entities;

namespace HouseRent.Core.Domain.Homes.Repositories;
public interface IHomeRepository
{
    Task<Home?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}