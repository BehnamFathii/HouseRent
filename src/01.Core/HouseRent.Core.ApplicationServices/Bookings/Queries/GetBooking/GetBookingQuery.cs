using HouseRent.Core.ApplicationServices.Extensions.Behaviors.QueryCaching;

namespace HouseRent.Core.ApplicationServices.Bookings.Queries.GetBooking;
public sealed record GetBookingQuery(long BookingId) : ICachedQuery<BookingResponse>
{
    public string CacheKey => $"BOOKING_BYID-{BookingId}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(10);
}
