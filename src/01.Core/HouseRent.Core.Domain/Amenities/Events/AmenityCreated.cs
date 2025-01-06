using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Homes.ValueObjects;
using HouseRent.Core.Domain.Shared.ValueObjects;

namespace HouseRent.Core.Domain.Amenities.Events;

public record AmenityCreated(long id,
                             Title title,
                             Description description,
                             Money money) : IDomainEvent;
