﻿using HouseRent.Core.Domain.Amenities.Events;
using HouseRent.Core.Domain.Amenities.Parameters;
using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Homes.Events;
using HouseRent.Core.Domain.Homes.ValueObjects;
using HouseRent.Core.Domain.Shared.ValueObjects;

namespace HouseRent.Core.Domain.Amenities.Entities;
public sealed class Amenity : AggregateRoot<long>
{
    private Amenity(long id, Title title, Money price, Description description) : base(id)
    {
        Title = title;
        Price = price;
        Description = description;
        IsActive = true;
    }

    public Title Title { get; private set; }
    public Money Price { get; private set; }
    public Description Description { get; private set; }
    public IsActive IsActive { get; private set; }

    public static Amenity Create(CreateAmenityParameter parameter)
    {
        var amenity = new Amenity(parameter.id, parameter.title, parameter.money, parameter.description);
        amenity.AddDomainEvent(new AmenityCreated(amenity.Id, amenity.Title, amenity.Description, amenity.Price));
        return amenity;
    }

    public void Update(UpdateAmenityParameter parameter)
    {
        Title = parameter.title;
        Description = parameter.description;
        Price = parameter.money;
        AddDomainEvent(new AmenityUpdated(Id, Title, Description, Price));
    }

    public void Active()
    {
        if (!IsActive.Value)
        {
            IsActive = IsActive.True();

            AddDomainEvent(new AmenityActived(Id));
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
}