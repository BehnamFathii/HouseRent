using HouseRent.Core.ApplicationServices.Contracts;
using IdGen.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace HouseRent.Infra.Utils.IdGeneratorService.Snowflake.Extensions.DependencyInjection;

public static class SnowflakeGeneratorRegistrer
{
    public static IServiceCollection RegisterSnowflakeGenerator(this IServiceCollection services,
                                                                         int idGeneratorId)
    {

        services.AddIdGen(idGeneratorId);
        services.AddSingleton<IIdGenerator<long>, SnowflakeIdGenerator>();
        return services;
    }
}
