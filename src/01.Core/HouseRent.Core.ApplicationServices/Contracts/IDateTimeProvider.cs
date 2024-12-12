namespace HouseRent.Core.ApplicationServices.Contracts;
public interface IDateTimeProvider
{
    DateTime GetUtcNow();

}