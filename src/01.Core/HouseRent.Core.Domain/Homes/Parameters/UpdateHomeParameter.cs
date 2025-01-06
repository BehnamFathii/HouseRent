using HouseRent.Core.Domain.Homes.Entities;
using HouseRent.Core.Domain.Homes.ValueObjects;
using HouseRent.Core.Domain.Shared.ValueObjects;

namespace HouseRent.Core.Domain.Homes.Parameters;

public record UpdateHomeParameter(Title title,
                                  Description description,
                                  Money money,
                                  List<HomeAmenity> amenities);

