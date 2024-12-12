using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Homes.Events;
using HouseRent.Core.Domain.Homes.Parameters;
using HouseRent.Core.Domain.Homes.ValueObjects;
using HouseRent.Core.Domain.Shared.ValueObjects;

namespace HouseRent.Core.Domain.Homes.Entities;
public sealed class Home : AggregateRoot<int>
{
    private Home(CreateHomeParameter parameter) : base(parameter.id)
    {
        Title = parameter.title;
        Description = parameter.description;
        Address = parameter.address;
        Price = parameter.money;
        Amenities = parameter.amenities;
        IsActive = true;
    }

    public Title Title { get; private set; }
    public Description Description { get; private set; }
    public Address Address { get; private set; }
    public Money Price { get; private set; }
    public List<int> Amenities { get; private set; } = [];
    public DateTime? LastBookedOnUtc { get; internal set; }
    public IsActive IsActive { get; private set; }

    public static Home Create(CreateHomeParameter parameter)
    {
        var home = new Home(parameter);
        home.AddDomainEvent(new HomeCreated(home.Id));
        return home;
    }

    public void Update(UpdateHomeParameter parameter)
    {
        Title = parameter.title;
        Description = parameter.description;
        Price = parameter.money;
        Amenities = parameter.amenities;
        AddDomainEvent(new HomeUpdated(Id, Title, Description, Price, Amenities));
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
