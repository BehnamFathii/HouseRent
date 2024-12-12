using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Homes.ValueObjects;
using HouseRent.Core.Domain.Shared.ValueObjects;

namespace HouseRent.Core.Domain.Homes.Events;
public record HomeUpdated(int id,
                          Title title,
                          Description description,
                          Money money,
                          List<int> amenities) : IDomainEvent;