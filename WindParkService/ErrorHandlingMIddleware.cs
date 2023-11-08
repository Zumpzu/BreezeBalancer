using Grpc.Core;
using Microsoft.AspNetCore.Http;


namespace WindParkService
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (RpcException)
            {
                // This exception is already in the correct format, so rethrow it.
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception has occurred while executing the request.");
                throw new RpcException(new Status(StatusCode.Internal, "Internal server error"));
            }
        }
    }
}
