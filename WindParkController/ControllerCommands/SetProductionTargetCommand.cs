using GrpcService;
using WindParkController.ControllerCommands;
using WindParkController.Model;

namespace WindParkController.ControllerTasks;

public class SetProductionTargetCommand : CommandBase<ProductionTargetChangeDto>
{
    private readonly WindParkManagement.WindParkManagementClient _client;
    
    public SetProductionTargetCommand(WindParkManagement.WindParkManagementClient client, ProductionTargetChangeDto productionTargetChangeDto) : base (productionTargetChangeDto)
    {
        _client = client;
    }

    public override async Task<ProductionTargetChangeDto> ExecuteAsync()
    {
        var request = new SetProductionTargetRequest { AdjustmentValue = CommandData.AdjustmentValue };
        var response = await _client.SetProductionTargetAsync(request);
        return new ProductionTargetChangeDto { AdjustmentValue = response.AdjustedValue };
    }
}