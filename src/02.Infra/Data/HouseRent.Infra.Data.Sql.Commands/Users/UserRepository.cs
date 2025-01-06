using HouseRent.Core.Domain.Users.Entities;
using HouseRent.Core.Domain.Users.Repositories;
using HouseRent.Infra.Data.Sql.Commands.Framework;
using HouseRent.Infra.Data.Sql.Commands.Shared;

namespace HouseRent.Infra.Data.Sql.Commands.Users;
internal sealed class UserRepository(HouseRentDbContext dbContext) :
    BaseCommandRepository<User, long>(dbContext), IUserRepository
{
}