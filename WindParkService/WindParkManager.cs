using GrpcService;
using WindParkService.DataModel;
using WindParkService.Services;

public interface IWindParkFacade
{
    void SetMarketPrice(float priceLimit);
    float AdjustProductionTarget(float adjustmentValue);
    Task<IEnumerable<TurbineProductionInfo>> GetTurbineProductionInfos();
}
public class WindParkFacade : IWindParkFacade
{
    private float _currentMarketPrice = 0;
    private float _currentProductionTarget = 0;

    private readonly ITurbineProductionService _turbineProductionService;
    private readonly ITurbineRepository _turbineRepository;

    public WindParkFacade(ITurbineRepository turbineRepository, ITurbineProductionService turbineProductionService)
    {
        _turbineRepository = turbineRepository;
        _turbineProductionService = turbineProductionService;

    }

    public void SetMarketPrice(float priceLimit)
    {
        try
        {
            _currentMarketPrice = priceLimit;
            var _ = UpdateTurbineStatusesAsync();
        }
        catch (Exception ex)
        {
            // Log the exception using the logger
            _logger.LogError(ex, "An error occurred while updating turbine statuses.");
        }
         // Fire and forget, but handle exceptions accordingly
    }

    public float AdjustProductionTarget(float adjustmentValue)
    {
        float newTarget = _currentProductionTarget + adjustmentValue;
        if (newTarget < 0)
        {
            newTarget = 0;
        }

        _currentProductionTarget = newTarget;
        var _ = UpdateTurbineStatusesAsync(); 
        return _currentProductionTarget;
    }


    private readonly SemaphoreSlim _updateSemaphore = new SemaphoreSlim(1, 1);
    public async Task UpdateTurbineStatusesAsync()
    {
        await _updateSemaphore.WaitAsync();
        try
        {
            var turbines = await _turbineRepository.GetAllTurbinesAsync(); 
            var sortedTurbines = turbines.OrderBy(t => t.ProductionCost);

            float productionNeeded = _currentProductionTarget;
            foreach (var turbine in sortedTurbines)
            {
                if (productionNeeded > 0 && _currentMarketPrice > turbine.ProductionCost)
                {
                    if (productionNeeded < turbine.MaxCapacity)
                    {
                        turbine.Stop();
                        continue;
                    }
                    turbine.Start();
                    productionNeeded -= turbine.MaxCapacity;
                }
                else
                {
                    turbine.Stop();
                }
                await _turbineRepository.UpdateTurbineAsync(turbine); 
            }
        }
        finally
        {
            _updateSemaphore.Release();
        }
    }
    public async Task<IEnumerable<TurbineProductionInfo>> GetTurbineProductionInfos()
    {
        return await _turbineProductionService.GetTurbineProductionInfos();
    }
}