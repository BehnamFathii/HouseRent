using HouseRent.Core.Domain.Shared.ValueObjects;

namespace HouseRent.Core.Domain.Bookings.ValueObjects;

public record PricingDetails(Money PriceForPeriod,Money AmenitiesUpCharge);

