using HouseRent.Core.Domain.Homes.Entities;
using HouseRent.Core.Domain.Homes.Repositories;
using HouseRent.Infra.Data.Sql.Commands.Framework;
using HouseRent.Infra.Data.Sql.Commands.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Infra.Data.Sql.Commands.Homes;
internal sealed class HomeRepository : BaseCommandRepository<Home, long>, IHomeRepository
{
    public HomeRepository(HouseRentDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Home?> GetGraphByIdAsync(long Id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Homes.Include(c => c.HomeAmenities).ThenInclude(c => c.Amenity).Where(c => c.Id == Id).FirstAsync(cancellationToken);
    }
}
