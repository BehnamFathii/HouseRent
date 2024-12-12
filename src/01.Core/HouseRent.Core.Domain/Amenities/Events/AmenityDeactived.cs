using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Amenities.Events;

public record AmenityDeactived(int id) : IDomainEvent;
