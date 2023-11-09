using Grpc.Core;
using GrpcService;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WindParkService.Services;
using Xunit;

namespace WindParkBackendTest;

[Trait("Category", "Unit")]
public class WindParkManagementServiceTests
{
    private readonly Mock<IWindParkManager> _mockFacade;
    private readonly Mock<ILogger<WindParkManagementService>> _mockLogger;
    private readonly WindParkManagementService _service;
    private readonly ServerCallContext _mockServerCallContext;

    public WindParkManagementServiceTests()
    {
        
        _mockFacade = new Mock<IWindParkManager>();
        _mockLogger = new Mock<ILogger<WindParkManagementService>>();
        _service = new WindParkManagementService(_mockFacade.Object, _mockLogger.Object);

        _mockServerCallContext = new Mock<ServerCallContext>().Object;
    }

    [Fact]
    public async Task SetProductionTarget_WithValidRequest_ShouldReturnAdjustedValue()
    {
        // Arrange
        var request = new SetProductionTargetRequest { AdjustmentValue = 10 };
        _mockFacade.Setup(f => f.AdjustProductionTarget(It.IsAny<float>())).Returns(10);

        // Act
        var response = await _service.SetProductionTarget(request, _mockServerCallContext);

        // Assert
        Assert.AreEqual(10, response.AdjustedValue);
        _mockFacade.Verify(f => f.AdjustProductionTarget(It.IsAny<float>()), Times.Once);
    }

    [Fact]
    public async Task SetMarketPrice_WithValidRequest_ShouldSetPriceLimit()
    {
        // Arrange
        var request = new SetMarketPriceRequest { PriceLimit = 50 };

        // Act
        var response = await _service.SetMarketPrice(request, _mockServerCallContext);

        // Assert
        Assert.AreEqual(50, response.PriceLimit);
        _mockFacade.Verify(f => f.SetMarketPrice(It.IsAny<float>()), Times.Once);
    }

    [Fact]
    public async Task GetTurbineProductions_ShouldReturnProductions()
    {
        // Arrange
        var productions = new List<TurbineProductionInfo> { new TurbineProductionInfo()
        {
            Id = 1,
            ExpectedProduction = 5,
            Name = "A"
        } };
        _mockFacade.Setup(f => f.GetTurbineProductionInfos()).ReturnsAsync(productions);

        // Act
        var response = await _service.GetTurbineProductions(new GetTurbineProductionsRequest(), _mockServerCallContext);

        // Assert
        Assert.AreEqual(productions.Count, response.Turbines.Count);
        
    }
}