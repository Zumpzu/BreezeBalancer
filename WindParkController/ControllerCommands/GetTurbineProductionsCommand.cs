using GrpcService;
using WindParkController.ControllerCommands;
using WindParkController.Model;

namespace WindParkController.ControllerTasks;

public class GetTurbineProductionsCommand : CommandBase<List<TurbineProductionInfoDto>>
{
    private readonly WindParkManagement.WindParkManagementClient _client;
    public GetTurbineProductionsCommand(WindParkManagement.WindParkManagementClient client) : base(null!) // hm..
    {
        _client = client;
    }

    public override async Task<List<TurbineProductionInfoDto>> ExecuteAsync()
    {
        var response = await _client.GetTurbineProductionsAsync(new GetTurbineProductionsRequest());

        return response.Turbines
            .Select(t => new TurbineProductionInfoDto
            {
                TurbineId = t.Id,
                ExpectedProduction = t.ExpectedProduction,
                Name = t.Name,
            }).ToList();
    }
}