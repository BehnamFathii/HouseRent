using HouseRent.Core.Domain.Amenities.Entities;
using HouseRent.Core.Domain.Amenities.Repositories;
using HouseRent.Infra.Data.Sql.Commands.Framework;
using HouseRent.Infra.Data.Sql.Commands.Shared;
using Microsoft.EntityFrameworkCore;

namespace HouseRent.Infra.Data.Sql.Commands.Amenities;
internal class AmentyRepository(HouseRentDbContext dbContext) :
    BaseCommandRepository<Amenity, long>(dbContext), IAmentyRepository
{
    public async Task<List<Amenity>> GetAmenitiesAsync(List<long> amenityIds, CancellationToken cancellationToken = default)
    {

        return await DbContext.Amenities.Where(c => amenityIds.Any(d => d == c.Id)).ToListAsync();
    }
}
