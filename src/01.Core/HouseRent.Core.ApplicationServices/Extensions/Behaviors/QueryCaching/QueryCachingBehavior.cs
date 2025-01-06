using HouseRent.Core.ApplicationServices.Contracts;
using HouseRent.Core.Domain.Framework;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HouseRent.Core.ApplicationServices.Extensions.Behaviors.QueryCaching;
public class QueryCachingBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICachedQuery
    where TResponse : Result
{
    private readonly ICacheService _cacheService;
    private readonly ILogger<QueryCachingBehavior<TRequest, TResponse>> _logger;

    public QueryCachingBehavior(ILogger<QueryCachingBehavior<TRequest, TResponse>> logger, ICacheService cacheService)
    {
        _logger = logger;
        _cacheService = cacheService;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        TResponse? cachedResult = await _cacheService.GetAsync<TResponse>(request.CacheKey, cancellationToken);

        if (cachedResult is not null)
        {
            return cachedResult;
        }

        string name = typeof(TRequest).Name;

        var result = await next();

        if (result.IsSuccess)
        {
            await _cacheService.SetAsync(request.CacheKey, result, request.Expiration, cancellationToken);
        }

        return result;
    }
}
