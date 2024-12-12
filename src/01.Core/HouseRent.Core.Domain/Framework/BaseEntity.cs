namespace HouseRent.Core.Domain.Framework;
public class BaseEntity<TId>(TId id)
{
    public TId Id { get; set; }
}
