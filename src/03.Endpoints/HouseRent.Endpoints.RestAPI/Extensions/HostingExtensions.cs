using HouseRent.Core.ApplicationServices.Extensions.DependencyInjection;
using HouseRent.Infra.Data.Sql.Commands.Extensions;
using HouseRent.Infra.Data.Sql.Commands.Shared;
using HouseRent.Infra.ExternalServices.Email.Fake.Extensions.DependencyInjection;
using HouseRent.Infra.Utils.DateTimeProviderService.Extensions.DependencyInjection;
using HouseRent.Infra.Utils.IdGeneratorService.Snowflake.Extensions.DependencyInjection;
using HouseRent.Infra.Caching.StackExchangeRedis.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace HouseRent.Endpoints.RestAPI.Extensions;

public static class HostingExtensions
{
    public static WebApplication ConfigureService(this WebApplicationBuilder builder)
    {

        var connectionString =
         builder.Configuration.GetConnectionString("CnnString") ??
         "throw new ArgumentNullException(nameof(configuration))";


        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.RegisterApplicaitonService();
        builder.Services.RegisterSimpleDateTime();
        builder.Services.RegisterFakeEmailService();
        builder.Services.RegisterSnowflakeGenerator(1);
        builder.Services.AddDbContext<HouseRentDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        builder.Services.RegisterDataAccessService(builder.Configuration);
        builder.Services.RegisterStackExchangeRedis(builder.Configuration);
        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.MapOpenApi();

        app.MapScalarApiReference();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
