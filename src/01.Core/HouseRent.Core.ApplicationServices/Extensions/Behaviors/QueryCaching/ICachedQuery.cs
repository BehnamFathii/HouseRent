using HouseRent.Core.ApplicationServices.Framework.Queries;

namespace HouseRent.Core.ApplicationServices.Extensions.Behaviors.QueryCaching;
public interface ICachedQuery<TResponse> : IQuery<TResponse>, ICachedQuery;

public interface ICachedQuery
{
    string CacheKey { get; }
    TimeSpan? Expiration { get; }
}