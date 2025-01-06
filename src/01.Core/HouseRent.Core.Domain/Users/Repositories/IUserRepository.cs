using HouseRent.Core.Domain.Users.Entities;

namespace HouseRent.Core.Domain.Users.Repositories;
public interface IUserRepository
{
    Task<User?> GetByIdAsync(long Id, CancellationToken cancellationToken = default);

    Task Add(User user, CancellationToken cancellationToken = default);
}