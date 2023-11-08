using Grpc.Core;
using GrpcService;

namespace WindParkService.Services
{
    public class WindParkManagementService : WindParkManagement.WindParkManagementBase
    {
        private readonly IWindParkManager _manager;
        private readonly ILogger<WindParkManagementService> _logger;

        public WindParkManagementService(IWindParkManager manager, ILogger<WindParkManagementService> logger)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override Task<SetProductionTargetResponse> SetProductionTarget(SetProductionTargetRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Request cannot be null"));
            }

            float newTarget = _manager.AdjustProductionTarget(request.AdjustmentValue);
            return Task.FromResult(new SetProductionTargetResponse { AdjustedValue = newTarget });
        }

        public override Task<SetMarketPriceResponse> SetMarketPrice(SetMarketPriceRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Request cannot be null"));
            }

            if (request.PriceLimit < 0)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "PriceLimit cannot be negative"));
            }

            _manager.SetMarketPrice(request.PriceLimit);
            return Task.FromResult(new SetMarketPriceResponse { PriceLimit = request.PriceLimit });
        }

        public override async Task<GetTurbineProductionsResponse> GetTurbineProductions(GetTurbineProductionsRequest request, ServerCallContext context)
        {
            var productions = await _manager.GetTurbineProductionInfos();
            var response = new GetTurbineProductionsResponse();
            response.Turbines.AddRange(productions);
            return response;
        }
    }
}
