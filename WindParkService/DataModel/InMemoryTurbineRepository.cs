namespace WindParkService.DataModel
{
    public interface ITurbineRepository
    {
        Task<IEnumerable<Turbine>> GetAllTurbinesAsync();
        Task UpdateTurbineAsync(Turbine turbine);
    }

    public class InMemoryTurbineRepository : ITurbineRepository
    {
        private List<Turbine> _turbines;
        private readonly object _lock = new object();

        // ... other members and methods ...

        public Task<IEnumerable<Turbine>> GetAllTurbinesAsync()
        {
            lock (_lock)
            {
                return Task.FromResult(_turbines.AsEnumerable());
            }
        }

        public Task UpdateTurbineAsync(Turbine turbine)
        {
            
            lock (_lock)
            {
                var existing = _turbines.FirstOrDefault(t => t.Id == turbine.Id);
                if (existing != null)
                {
                    if (turbine.IsRunning)
                    {
                        existing.Start();
                    }
                    else
                    {
                        existing.Stop();
                    }
                }

                return Task.CompletedTask;
            }
        }
    }
}
