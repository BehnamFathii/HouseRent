using IdGen;

namespace HouseRent.Infra.Utils.IdGeneratorService.Snowflake;

public class SnowflakeIdGenerator(IdGenerator generator) : Core.ApplicationServices.Contracts.IIdGenerator<long>
{
    private readonly IdGenerator _generator = generator;

    public long GetId()
    {
        return _generator.CreateId();
    }
}
