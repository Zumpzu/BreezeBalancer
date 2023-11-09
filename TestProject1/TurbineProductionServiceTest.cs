using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WindParkService.DataModel;
using WindParkService.Services;
using Xunit;

namespace WindParkBackendTest
{
    [Trait("Category", "Unit")]
    public class TurbineProductionServiceTests
    {
        [Fact]
        public void GetTurbineProductionInfos_ShouldReturnTurbines_WithAndWithoutExpectedProductionVAlues()
        {
            // Arrange
            var turbines = new List<Turbine>
            {
                new Turbine (1, 2, 15, "A" )
                {
                    IsRunning = true,
                },
                new Turbine (2, 2, 5 , "B")
                {
                    IsRunning = true,
                },
                new Turbine (3, 6, 5 , "C" ),
                new Turbine (4, 6, 5 , "D")
                {
                    IsRunning = true
                },
                new Turbine (5, 5, 3 , "E"),
            };

            var mockTurbineRepository = new Mock<ITurbineRepository>();
            mockTurbineRepository.Setup(repo => repo.GetAllTurbinesAsync()).ReturnsAsync(turbines);

            var service = new TurbineParkProductionInfoService(mockTurbineRepository.Object);

            // Act
            var turbineProductionInfos = service.GetTurbineProductionInfos().Result.ToList();

            // Assert
            Assert.IsNotNull(turbineProductionInfos);
            Assert.AreEqual(5, turbineProductionInfos.Count);

            Assert.AreEqual("A", turbineProductionInfos[0].Name);

            Assert.AreEqual(2, turbineProductionInfos[0].ExpectedProduction);

            Assert.AreEqual(0, turbineProductionInfos[2].ExpectedProduction);
        }
    }
}