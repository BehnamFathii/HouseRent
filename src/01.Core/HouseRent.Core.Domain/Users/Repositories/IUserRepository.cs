using HouseRent.Core.Domain.Users.Entities;

namespace HouseRent.Core.Domain.Users.Repositories;
public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void Add(User user);
}