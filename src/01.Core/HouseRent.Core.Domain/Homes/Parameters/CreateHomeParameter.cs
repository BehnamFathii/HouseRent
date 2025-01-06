using HouseRent.Core.Domain.Homes.Entities;
using HouseRent.Core.Domain.Homes.ValueObjects;
using HouseRent.Core.Domain.Shared.ValueObjects;

namespace HouseRent.Core.Domain.Homes.Parameters;
public record CreateHomeParameter(int id,
                                  Title title,
                                  Description description,
                                  Address address,
                                  Money money,
                                  List<HomeAmenity> amenities);

