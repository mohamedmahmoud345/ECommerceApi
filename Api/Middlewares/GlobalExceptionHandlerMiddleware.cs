using FluentValidation;

namespace Api.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;
        private readonly IWebHostEnvironment _environment;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _environment = env;
        }   

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ValidationException ex)
            {
                _logger.LogError(ex, "FluentValidation exception");

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                var errors = ex.Errors
                    .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                    .ToDictionary(
                        failureGroup => failureGroup.Key,
                        failureGroup => failureGroup.ToArray());

                var result = new { errors };

                await context.Response.WriteAsJsonAsync(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var problem = new
                {
                    status = context.Response.StatusCode,
                    title = "An unexpected error occurred.",
                    detail = _environment.IsDevelopment() ? ex.Message : "Internal Server Error",
                    traceId = context.TraceIdentifier
                };

                await context.Response.WriteAsJsonAsync(problem);
            }
        }
    }
}
