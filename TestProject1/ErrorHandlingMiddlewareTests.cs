using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WindParkService;
using Xunit;

namespace WindParkBackendTest;

[Trait("Category", "Unit")]
public class ErrorHandlingMiddlewareTests
{
    private readonly ILogger<ErrorHandlingMiddleware> _mockLogger;
    private readonly RequestDelegate _requestDelegate;

    public ErrorHandlingMiddlewareTests()
    {
        _mockLogger = Mock.Of<ILogger<ErrorHandlingMiddleware>>();

        // Simulate a middleware that throws an exception
        _requestDelegate = (HttpContext httpContext) =>
        {
            throw new InvalidOperationException("Test exception");
        };
    }

    [Fact]
    public async Task InvokeAsync_HandlesExceptionsByLoggingAndRethrowingAsRpcException()
    {
        // Arrange
        var middleware = new ErrorHandlingMiddleware(_requestDelegate, _mockLogger);
        var context = new DefaultHttpContext();

        // Act & Assert
        var exception = await Assert.ThrowsExceptionAsync<RpcException>(() => middleware.InvokeAsync(context));

        // Verify that the exception is converted to an RpcException with the correct status code
        Assert.AreEqual(StatusCode.Internal, exception.Status.StatusCode);
        Assert.AreEqual("Internal server error", exception.Status.Detail);
    }
}