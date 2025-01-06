using HouseRent.Core.Domain.Amenities.Entities;
using HouseRent.Core.Domain.Bookings.Entities;

namespace HouseRent.Core.Domain.Amenities.Repositories;
public interface IAmentyRepository
{
    Task<Amenity?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<List<Amenity>> GetAmenitiesAsync(List<long> amenityIds, CancellationToken cancellationToken = default);
}