using Grpc.Net.Client;
using GrpcService;
using WindParkController.Controllers;
using WindParkController.Model;

namespace WindParkController;
//public interface IBackendCommunicationWrapper
//{
//    Task<ProductionTargetChangeDto> SetProductionTargetAsync(float myValue);
//    Task<MarketPriceDto> SetMarketPriceAsync(float priceLimit);
//    Task<List<TurbineProductionInfoDto>> GetTurbineProductionsAsync();
//}
//public class BackendCommunicationWrapper : IBackendCommunicationWrapper
//{
//    private readonly ILogger<BackendCommunicationWrapper> _logger;
//    private readonly WindParkManagement.WindParkManagementClient _client;

//    public BackendCommunicationWrapper(ILogger<BackendCommunicationWrapper> logger, GrpcChannel channel)
//    {
//        _logger = logger;
//        _client = new WindParkManagement.WindParkManagementClient(channel);
//    }

//    public async Task<ProductionTargetChangeDto> AdjustProductionTargetAsync(float myValue)
//    {
//        var request = new SetProductionTargetRequest { AdjustmentValue = myValue };
//        var response = await _client.SetProductionTargetAsync(request);

        
//        var dto = new ProductionTargetChangeDto
//        {
//            AdjustmentValue = response.AdjustedValue
//        };

//        return dto;
//    }

//    public Task<ProductionTargetChangeDto> SetProductionTargetAsync(float myValue)
//    {
//        throw new NotImplementedException();
//    }

//    public async Task<MarketPriceDto> SetMarketPriceAsync(float priceLimit)
//    {
        
//        var request = new SetMarketPriceRequest { PriceLimit = priceLimit };
//        await _client.SetMarketPriceAsync(request);

//        var dto = new MarketPriceDto
//        {
//            PriceLimit = priceLimit
//        };

//        return dto;
//    }

//    public async Task<List<TurbineProductionInfoDto>> GetTurbineProductionsAsync()
//    {
//        var request = new GetTurbineProductionsRequest();
//        var response = await _client.GetTurbineProductionsAsync(request);

//        var dtos = response.Turbines
//            .Select(t => new TurbineProductionInfoDto
//            {
//                TurbineId = t.TurbineId,
//                ExpectedProduction = t.ExpectedProduction
//            }).ToList();

//        return dtos;
//    }
//}