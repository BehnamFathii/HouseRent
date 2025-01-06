﻿namespace HouseRent.Core.ApplicationServices.Bookings.Queries.GetBooking;
public sealed class BookingResponse
{
    public long Id { get; init; }

    public long UserId { get; init; }

    public int ApartmentId { get; init; }

    public int Status { get; init; }

    public int PriceForPeriod { get; init; }

    public int AmenitiesUpCharge { get; init; }

    public int TotalPriceAmount { get; init; }

    public DateOnly DurationStart { get; init; }

    public DateOnly DurationEnd { get; init; }

    public DateTime CreatedOnUtc { get; init; }

    public DateTime HostStatusOnUtc { get; set; }
    public DateTime GuestStatusOnUtc { get; set; }
}