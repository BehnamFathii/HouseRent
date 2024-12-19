using HouseRent.Core.Domain.Bookings.Entities;
using HouseRent.Core.Domain.Bookings.ValueObjects;
using HouseRent.Core.Domain.Homes.Entities;

namespace HouseRent.Core.Domain.Bookings.Repositories;
public interface IBookingRepository
{
    Task<Booking> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<bool> IsOverlappingAsync(
        Home home,
        DateRange duration,
        CancellationToken cancellationToken = default);

    Task AddAsync(Booking booking, CancellationToken cancellationToken = default);
}
