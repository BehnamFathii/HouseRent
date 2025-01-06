using Dapper;
using HouseRent.Core.ApplicationServices.Contracts;
using HouseRent.Core.Domain.Amenities.Repositories;
using HouseRent.Core.Domain.Bookings.Repositories;
using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Homes.Repositories;
using HouseRent.Core.Domain.Users.Repositories;
using HouseRent.Infra.Data.Sql.Commands.Amenities;
using HouseRent.Infra.Data.Sql.Commands.Bookings;
using HouseRent.Infra.Data.Sql.Commands.ConnectionFactory;
using HouseRent.Infra.Data.Sql.Commands.Framework;
using HouseRent.Infra.Data.Sql.Commands.Homes;
using HouseRent.Infra.Data.Sql.Commands.Shared;
using HouseRent.Infra.Data.Sql.Commands.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HouseRent.Infra.Data.Sql.Commands.Extensions;
public static class SqlCommandRegistrer
{
    public static IServiceCollection RegisterDataAccessService(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
                    configuration.GetConnectionString("HouseRentCnn") ??
                    throw new ArgumentNullException("Connection String not found. check the name of connection string in configuration file");

        services.AddDbContext<HouseRentDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IHomeRepository, HomeRepository>();

        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IAmentyRepository, AmentyRepository>();

        services.AddScoped<IUnitOfWork, UnitofWork>();

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));


        return services;
    }
}
