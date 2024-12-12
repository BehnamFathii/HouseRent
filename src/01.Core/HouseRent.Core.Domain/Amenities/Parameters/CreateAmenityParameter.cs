using HouseRent.Core.Domain.Homes.ValueObjects;
using HouseRent.Core.Domain.Shared.ValueObjects;

namespace HouseRent.Core.Domain.Amenities.Parameters;

public record CreateAmenityParameter(int id,
                                     Title title,
                                     Money money,
                                     Description description);


