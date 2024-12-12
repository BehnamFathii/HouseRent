using HouseRent.Core.Domain.Amenities.Entities;
using HouseRent.Core.Domain.Bookings.Entities;

namespace HouseRent.Core.Domain.Amenities.Repositories;
public interface IAmentyRepository
{
    Task<Booking?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void AddAsync(Booking booking, CancellationToken cancellationToken = default);
    Task<List<Amenity>> GetAmenitiesAsync(List<int> amenityIds, CancellationToken cancellationToken = default);

}