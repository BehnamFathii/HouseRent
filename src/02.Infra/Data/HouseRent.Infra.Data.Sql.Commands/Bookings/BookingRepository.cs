using HouseRent.Core.Domain.Bookings.Entities;
using HouseRent.Core.Domain.Bookings.Enums;
using HouseRent.Core.Domain.Bookings.Repositories;
using HouseRent.Core.Domain.Bookings.ValueObjects;
using HouseRent.Core.Domain.Homes.Entities;
using HouseRent.Infra.Data.Sql.Commands.Framework;
using HouseRent.Infra.Data.Sql.Commands.Shared;
using Microsoft.EntityFrameworkCore;

namespace HouseRent.Infra.Data.Sql.Commands.Bookings;
internal sealed class BookingRepository(HouseRentDbContext dbContext) :
    BaseCommandRepository<Booking, long>(dbContext), IBookingRepository
{
    private static readonly BookingStatus[] ActiveBookingStatuses =
    {
        BookingStatus.Reserved,
        BookingStatus.Confirmed,
        BookingStatus.Completed
    };

    public async Task<bool> IsOverlappingAsync(
        Home home,
        DateRange duration,
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<Booking>()
            .AnyAsync(
                booking =>
                    booking.HomeId == home.Id &&
                    booking.Duration.Start <= duration.End &&
                    booking.Duration.End >= duration.Start &&
                    ActiveBookingStatuses.Contains(booking.Status),
                cancellationToken);
    }
}