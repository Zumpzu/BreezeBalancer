using Grpc.Core;
using GrpcService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WindParkController.ControllerTasks;
using Xunit;

namespace WindParkBackendTest;

public class GetTurbineProductionsCommandTests
{
    private readonly Mock<WindParkManagement.WindParkManagementClient> _mockClient;
    private readonly GetTurbineProductionsCommand _command;

    public GetTurbineProductionsCommandTests()
    {
        _mockClient = new Mock<WindParkManagement.WindParkManagementClient>();
        _command = new GetTurbineProductionsCommand(_mockClient.Object);
    }

    [Fact]
    public async Task ExecuteAsync_CallsGetTurbineProductionsAndReturnsCorrectData()
    {
        // Arrange
        var mockResponse = new GetTurbineProductionsResponse
        {
            Turbines =
            {
                new TurbineProductionInfo { Id = 1, ExpectedProduction = 10, Name = "Turbine 1" },
                
            }
        };
        _mockClient.Setup(client => client.GetTurbineProductionsAsync(It.IsAny<GetTurbineProductionsRequest>(), null, null, CancellationToken.None)).Returns(CreateAsyncUnaryCall(mockResponse));

        // Act
        var result = await _command.ExecuteAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(mockResponse.Turbines.Count, result.Count);
        Assert.AreEqual(mockResponse.Turbines[0].ExpectedProduction, result[0].ExpectedProduction);
        Assert.AreEqual(mockResponse.Turbines[0].Name, result[0].Name);

        // Verify the gRPC client was called
        _mockClient.Verify(client => client.GetTurbineProductionsAsync(It.IsAny<GetTurbineProductionsRequest>(), null, null, CancellationToken.None), Times.Once);
    }


    public static AsyncUnaryCall<TResponse> CreateAsyncUnaryCall<TResponse>(TResponse response)
    {
        return new AsyncUnaryCall<TResponse>(

            Task.FromResult(response),
            Task.FromResult(new Metadata()),
            () => Status.DefaultSuccess,
            () => new Metadata(),
            () => { });
    }
}