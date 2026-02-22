using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Behaviors
{
    public class LoggingPipelineBehaviors<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingPipelineBehaviors<TRequest, TResponse>> _logger;
        public LoggingPipelineBehaviors(ILogger<LoggingPipelineBehaviors<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Starting Request {@RequestName}, {@DateTimeUtc}",
                typeof(TRequest).Name,
                DateTime.UtcNow
            );

            var result = await next();

            _logger.LogInformation(
                "Completed Request {@RequestName}, {@DateTimeUtc}",
                typeof(TRequest).Name,
                DateTime.UtcNow
                );

            return result;
        }
    }
}
