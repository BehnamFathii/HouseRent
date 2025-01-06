using HouseRent.Core.Domain.Framework;

namespace HouseRent.Infra.Data.Sql.Commands.Shared;
internal class UnitofWork(HouseRentDbContext dbContext) : IUnitOfWork
{
    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}