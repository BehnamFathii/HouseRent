using HouseRent.Core.ApplicationServices.Contracts;
using HouseRent.Infra.Caching.StackExchangeRedis.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HouseRent.Infra.Caching.StackExchangeRedis.Extensions.DependencyInjection;
public static class StackExchangeRedisRegistrer
{
    public static IServiceCollection RegisterStackExchangeRedis(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Cache") ??
            throw new ArgumentNullException(nameof(configuration));
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = connectionString;
            options.InstanceName = "";
        });
        services.AddSingleton<ICacheService, CacheService>();

        return services;
    }
}
