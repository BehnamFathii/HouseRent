using HouseRent.Core.Domain.Bookings.Services;
using HouseRent.Core.Domain.Bookings.ValueObjects;
using HouseRent.Core.Domain.Homes.Entities;

namespace HouseRent.Core.Domain.Bookings.Parameters;
public record ReserveParamater(int Id,
                               Home Home,
                               int UserId,
                               DateRange Duration,
                               DateTime UtcNow,
                               PricingService PricingService);   // double dispatch pattern
