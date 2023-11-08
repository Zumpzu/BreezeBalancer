using GrpcService;
using WindParkService.DataModel;

namespace WindParkService.Services
{
    public interface ITurbineProductionService
    {
        Task<IEnumerable<TurbineProductionInfo>> GetTurbineProductionInfos();
    }
    public class TurbineParkProductionInfoService : ITurbineProductionService
    {
        private readonly ITurbineRepository _turbineRepository;

        public TurbineParkProductionInfoService(ITurbineRepository turbineRepository)
        {
            _turbineRepository = turbineRepository;
        }

        public async Task<IEnumerable<TurbineProductionInfo>> GetTurbineProductionInfos()
        {
            var runningTurbines = await _turbineRepository.GetAllTurbinesAsync();
            return runningTurbines.Select(t => new TurbineProductionInfo
            {
                Id = t.Id,
                ExpectedProduction = t.IsRunning ? t.MaxCapacity : 0,
                Name = t.Name,
            });
        }
    }
}
