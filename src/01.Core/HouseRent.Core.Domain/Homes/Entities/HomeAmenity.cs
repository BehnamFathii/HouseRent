using HouseRent.Core.Domain.Amenities.Entities;
using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Homes.Entities;
public class HomeAmenity(long id) : BaseEntity<long>(id)
{
    public Home Home { get; set; }
    public Amenity Amenity { get; set; }
    public long HomeId { get; set; }
    public long AmenityId { get; set; }
}
