using HouseRent.Core.ApplicationServices.Contracts;
using HouseRent.Infra.ExternalServices.Email.Fake;
using Microsoft.Extensions.DependencyInjection;

namespace HouseRent.Infra.ExternalServices.Email.Fake.Extensions.DependencyInjection;
public static class FakeEmailServiceRegistrer
{
    public static IServiceCollection RegisterFakeEmailService(this IServiceCollection services)
    {
        services.AddTransient<IEmailService, FakeEmailService>();

        return services;
    }
}
