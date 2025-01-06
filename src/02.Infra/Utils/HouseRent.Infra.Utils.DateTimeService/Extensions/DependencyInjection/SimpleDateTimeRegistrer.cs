using HouseRent.Core.ApplicationServices.Contracts;
using HouseRent.Infra.Utils.DateTimeProviderService;
using Microsoft.Extensions.DependencyInjection;

namespace HouseRent.Infra.Utils.DateTimeProviderService.Extensions.DependencyInjection;
public static class SimpleDateTimeRegistrer
{
    public static IServiceCollection RegisterSimpleDateTime(this IServiceCollection services)
    {
        services.AddTransient<IDateTimeProvider, SimpleDateTime>();

        return services;
    }
}
