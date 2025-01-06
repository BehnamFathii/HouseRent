namespace HouseRent.Core.ApplicationServices.Contracts;
public interface IIdGenerator<T>
{
    T GetId();
}