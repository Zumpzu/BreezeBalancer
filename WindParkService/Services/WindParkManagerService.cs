using Grpc.Core;
using GrpcService;

namespace WindParkService.Services
{
    public class WindParkManagementService : WindParkManagement.WindParkManagementBase
    {
        private readonly IWindParkFacade _facade;
        private readonly ILogger<WindParkManagementService> _logger;

        public WindParkManagementService(IWindParkFacade facade, ILogger<WindParkManagementService> logger)
        {
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override async Task<SetProductionTargetResponse> SetProductionTarget(SetProductionTargetRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Request cannot be null"));
            }

            float newTarget = _facade.AdjustProductionTarget(request.AdjustmentValue);
            return new SetProductionTargetResponse { AdjustedValue = newTarget };
        }

        public override async Task<SetMarketPriceResponse> SetMarketPrice(SetMarketPriceRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Request cannot be null"));
            }

            if (request.PriceLimit < 0)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "PriceLimit cannot be negative"));
            }

            _facade.SetMarketPrice(request.PriceLimit);
            return new SetMarketPriceResponse { PriceLimit = request.PriceLimit };
        }

        public override async Task<GetTurbineProductionsResponse> GetTurbineProductions(GetTurbineProductionsRequest request, ServerCallContext context)
        {
            // Assuming there is no input to validate for GetTurbineProductionsRequest
            var productions = await _facade.GetTurbineProductionInfos();
            var response = new GetTurbineProductionsResponse();
            response.Turbines.AddRange(productions);
            return response;
        }
    }
}
