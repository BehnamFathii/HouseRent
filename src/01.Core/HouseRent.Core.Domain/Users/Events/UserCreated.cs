using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Users.Events;
public record UserCreated(int id) : IDomainEvent;