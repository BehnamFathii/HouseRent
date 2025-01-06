using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Amenities.Events;

public record AmenityActived(long id) : IDomainEvent;