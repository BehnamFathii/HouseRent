using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Homes.Events;

public record HomeBooked(long id) : IDomainEvent;
