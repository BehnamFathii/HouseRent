using HouseRent.Core.Domain.Bookings.Enums;
using HouseRent.Core.Domain.Bookings.ValueObjects;
using HouseRent.Core.Domain.Shared.ValueObjects;

namespace HouseRent.Core.Domain.Bookings.Parameters;
public record CreateBookingParameters(int Id,
                                     int HomeId,
                                     int UserId,
                                     DateRange Duration,
                                     Money PriceForPeriod,
                                     Money AmenitiesUpCharge,
                                     BookingStatus Status,
                                     DateTime CreatedOnUtc);

