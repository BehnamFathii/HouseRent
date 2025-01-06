using HouseRent.Core.Domain.Amenities.Events;
using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Homes.Events;
using HouseRent.Core.Domain.Homes.ValueObjects;
using HouseRent.Core.Domain.Users.Events;
using HouseRent.Core.Domain.Users.Parameters;
using HouseRent.Core.Domain.Users.ValueObjects;

namespace HouseRent.Core.Domain.Users.Entities;
public sealed class User : AggregateRoot<long>
{
    private User(long id, FirstName firstName, LastName lastName, Email email)
     : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        IsActive = true;
    }
    private User() : base()
    {

    }

    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
    public IsActive IsActive { get; private set; }

    public static User Create(CreateUserParameter parameter)
    {
        var user = new User(parameter.id, parameter.firstName, parameter.lastName, parameter.emil);
        user.AddDomainEvent(new UserCreated(parameter.id));
        return user;
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
