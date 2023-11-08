using Grpc.Net.Client;
using GrpcService;
using Microsoft.AspNetCore.Mvc;
using WindParkController.ControllerTasks;
using WindParkController.Model;
using WindParkController.ModelValidationFilter;

namespace WindParkController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindParkController : ControllerBase
    {
        private readonly ILogger<WindParkController> _logger;
        private readonly WindParkManagement.WindParkManagementClient _client;
        
        public WindParkController(ILogger<WindParkController> logger, GrpcChannel channel)
        {
            _logger = logger;
            _client = new WindParkManagement.WindParkManagementClient(channel);
        }

        
        [HttpPost("productiontarget")]
        [ValidateModel]
        public async Task<IActionResult> AdjustProductionTargetAsync([FromBody] ProductionTargetChangeDto dto)
        {
            var command = new SetProductionTargetCommand(_client, dto);
            var result = await command.ExecuteAsync();
            return Ok(result);
        }

        
        [HttpPost("marketprice")]
        [ValidateModel]
        public async Task<IActionResult> SetMarketPriceAsync([FromBody] MarketPriceDto dto)
        {
            var command = new SetMarketPriceCommand(_client, dto);
            var result = await command.ExecuteAsync();
            return Ok(result);
        }

        [HttpGet("turbineproductions")]
        [ValidateModel]
        public async Task<IActionResult> GetTurbineProductionsAsync()
        {

            var command = new GetTurbineProductionsCommand(_client);
            var result = await command.ExecuteAsync();
            return Ok(result);
        }
    }
}
