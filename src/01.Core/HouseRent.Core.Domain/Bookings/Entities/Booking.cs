using HouseRent.Core.Domain.Bookings.Enums;
using HouseRent.Core.Domain.Bookings.Errors;
using HouseRent.Core.Domain.Bookings.Events;
using HouseRent.Core.Domain.Bookings.Parameters;
using HouseRent.Core.Domain.Bookings.Services;
using HouseRent.Core.Domain.Bookings.ValueObjects;
using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Homes.Entities;
using HouseRent.Core.Domain.Shared.ValueObjects;

namespace HouseRent.Core.Domain.Bookings.Entities;
public sealed class Booking : AggregateRoot<int>
{
    private Booking(CreateBookingParameters parameters) : base(parameters.Id)
    {
        HomeId = parameters.HomeId;
        UserId = parameters.UserId;
        Duration = parameters.Duration;
        PriceForPeriod = parameters.PriceForPeriod;
        AmenitiesUpCharge = parameters.AmenitiesUpCharge;
        Status = parameters.Status;
        CreatedOnUtc = parameters.CreatedOnUtc;
    }

    public int HomeId { get; private set; }

    public int UserId { get; private set; }

    public DateRange Duration { get; private set; }

    public Money PriceForPeriod { get; private set; }
    public Money AmenitiesUpCharge { get; private set; }

    public Money TotalPrice => PriceForPeriod + AmenitiesUpCharge;

    public BookingStatus Status { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public DateTime? HostStatusOnUtc { get; private set; }


    public DateTime? GuestStatusOnUtc { get; private set; }

    public static Booking Reserve(int id,
        Home home,
        int userId,
        DateRange duration,
        DateTime utcNow,
        PricingService pricingService)
    {
        var pricingDetails = pricingService.CalculatePrice(home, duration);

        var booking = new Booking(new CreateBookingParameters(Id: id,
        HomeId: home.Id,
        UserId: userId,
        Duration: duration,
        PriceForPeriod: pricingDetails.PriceForPeriod,
        AmenitiesUpCharge: pricingDetails.AmenitiesUpCharge,
        Status: BookingStatus.Reserved,
        CreatedOnUtc: utcNow));

        booking.AddDomainEvent(new BookingReservedDomainEvent(booking.Id));

        home.Reserve(utcNow);

        return booking;
    }

    public Result Confirm(DateTime utcNow)
    {
        if (Status != BookingStatus.Reserved)
        {
            return Result.Failure(BookingErrors.NotReserved);
        }

        Status = BookingStatus.Confirmed;
        HostStatusOnUtc = utcNow;

        AddDomainEvent(new BookingConfirmedDomainEvent(Id));

        return Result.Success();
    }

    public Result Reject(DateTime utcNow)
    {
        if (Status != BookingStatus.Reserved)
        {
            return Result.Failure(BookingErrors.NotReserved);
        }

        Status = BookingStatus.Rejected;
        HostStatusOnUtc = utcNow;

        AddDomainEvent(new BookingRejectedDomainEvent(Id));

        return Result.Success();
    }

    public Result Complete(DateTime utcNow)
    {
        if (Status != BookingStatus.Confirmed)
        {
            return Result.Failure(BookingErrors.NotConfirmed);
        }

        Status = BookingStatus.Completed;
        GuestStatusOnUtc = utcNow;

        AddDomainEvent(new BookingCompletedDomainEvent(Id));

        return Result.Success();
    }

    public Result Cancel(DateTime utcNow)
    {
        if (Status != BookingStatus.Confirmed)
        {
            return Result.Failure(BookingErrors.NotConfirmed);
        }

        var currentDate = DateOnly.FromDateTime(utcNow);

        if (currentDate > Duration.Start)
        {
            return Result.Failure(BookingErrors.AlreadyStarted);
        }

        Status = BookingStatus.Cancelled;
        GuestStatusOnUtc = utcNow;

        AddDomainEvent(new BookingCancelledDomainEvent(Id));

        return Result.Success();
    }
}