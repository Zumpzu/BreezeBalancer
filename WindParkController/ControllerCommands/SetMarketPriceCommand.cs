using GrpcService;
using System.Windows.Input;
using WindParkController.ControllerCommands;
using WindParkController.Model;

namespace WindParkController.ControllerTasks;

public class SetMarketPriceCommand : CommandBase<MarketPriceDto>
{
    private readonly WindParkManagement.WindParkManagementClient _client;
    
    public SetMarketPriceCommand(WindParkManagement.WindParkManagementClient client, MarketPriceDto objectToCommand) : base(objectToCommand)
    {
        _client = client;
    }
    public override async Task<MarketPriceDto> ExecuteAsync()
    {
        var request = new SetMarketPriceRequest { PriceLimit = CommandData.PriceLimit };
        var response = await _client.SetMarketPriceAsync(request);
        return new MarketPriceDto { PriceLimit = response.PriceLimit };
    }
}