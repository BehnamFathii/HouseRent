using HouseRent.Core.ApplicationServices.Contracts;

namespace HouseRent.Infra.Utils.DateTimeProviderService;

public class SimpleDateTime : IDateTimeProvider
{
    public DateTime GetUtcNow() => DateTime.UtcNow;
}
