using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Homes.Events;
using HouseRent.Core.Domain.Homes.Parameters;
using HouseRent.Core.Domain.Homes.ValueObjects;
using HouseRent.Core.Domain.Shared.ValueObjects;

namespace HouseRent.Core.Domain.Homes.Entities;
public sealed class Home : AggregateRoot<long>
{
    private Home(
       long id,
       Title title,
       Description description,
       Address address,
       Money price,
       List<HomeAmenity> amenities)
       : base(id)
    {
        Title = title;
        Description = description;
        Address = address;
        Price = price;
        HomeAmenities = amenities;
        IsActive = true;
    }
    private Home() : base()
    {

    }

    public Title Title { get; private set; }
    public Description Description { get; private set; }
    public Address Address { get; private set; }
    public Money Price { get; private set; }
    public List<HomeAmenity> HomeAmenities { get; private set; } = [];
    public DateTime? LastBookedOnUtc { get; internal set; }
    public IsActive IsActive { get; private set; }

    public static Home Create(CreateHomeParameter parameter)
    {
        var home = new Home(parameter.id,parameter.title, parameter.description, parameter.address, parameter.money, parameter.amenities);
        home.AddDomainEvent(new HomeCreated(home.Id));
        return home;
    }

    public void Update(UpdateHomeParameter parameter)
    {
        Title = parameter.title;
        Description = parameter.description;
        Price = parameter.money;
        HomeAmenities = parameter.amenities;
        AddDomainEvent(new HomeUpdated(Id, Title, Description, Price, HomeAmenities));
    }

    public void Active()
    {
        if (!IsActive.Value)
        {
            IsActive = IsActive.True();

            AddDomainEvent(new HomeActived(Id));
        }
    }


    public void Deactive()
    {
        if (IsActive.Value)
        {
            IsActive = IsActive.False();

            AddDomainEvent(new HomeDeactived(Id));
        }
    }

    public Result Reserve(DateTime dateTimeUtc)
    {
        LastBookedOnUtc = dateTimeUtc;
        AddDomainEvent(new HomeBooked(Id));
        return Result.Success();
    }
}
