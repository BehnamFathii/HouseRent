using HouseRent.Core.Domain.Amenities.Entities;
using HouseRent.Core.Domain.Bookings.ValueObjects;
using HouseRent.Core.Domain.Homes.Entities;
using HouseRent.Core.Domain.Shared.ValueObjects;

namespace HouseRent.Core.Domain.Bookings.Services;
public class PricingService(List<Amenity> Amenities)
{
    public PricingDetails CalculatePrice(Home home, DateRange period)
    {
        var priceForPeriod = new Money(home.Price.Amount * period.LengthInDays);

        int upCharge = 0;
        foreach (var amenity in Amenities)
        {
            upCharge += amenity.Price.Amount;
        }
        return new PricingDetails(priceForPeriod, new Money(upCharge));
    }
}
