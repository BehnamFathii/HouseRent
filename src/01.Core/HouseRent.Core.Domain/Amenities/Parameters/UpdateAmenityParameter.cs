using HouseRent.Core.Domain.Homes.ValueObjects;
using HouseRent.Core.Domain.Shared.ValueObjects;

namespace HouseRent.Core.Domain.Amenities.Parameters;

public record UpdateAmenityParameter(int id,
                                  Title title,
                                  Description description,
                                  Money money);


