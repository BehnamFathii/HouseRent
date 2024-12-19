using FluentValidation;
using HouseRent.Core.ApplicationServices.Extensions.Behaviors.Logging;
using HouseRent.Core.ApplicationServices.Extensions.Behaviors.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace HouseRent.Core.ApplicationServices.Extensions.DependencyInjection;
public static class ApplicationRegistrer
{
    public static IServiceCollection RegisterApplicationService(this IServiceCollection services)
    {
        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssemblyContaining(typeof(ApplicationRegistrer));
            c.AddOpenBehavior(typeof(LoggingBehavior<,>));
            c.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(ApplicationRegistrer).Assembly);

        return services;
    }
}
