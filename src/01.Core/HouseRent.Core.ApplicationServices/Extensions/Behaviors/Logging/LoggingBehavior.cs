﻿using HouseRent.Core.ApplicationServices.Framework.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HouseRent.Core.ApplicationServices.Extensions.Behaviors.Logging;
public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var name = request.GetType().Name;

        try
        {
            _logger.LogInformation("Executing command {Command} at {DateTimeUtc}", name, DateTime.UtcNow);

            var result = await next();

            _logger.LogInformation("Command {Command} processed successfully at {DateTimeUtc}", name, DateTime.UtcNow);

            return result;
        }
        catch (Exception)
        {
            _logger.LogError("Command {Command} processing failed at {DateTimeUtc}", name, DateTime.UtcNow);

            throw;
        }
    }
}
