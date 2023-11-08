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

        public InMemoryTurbineRepository()
        {
            
            _turbines = new List<Turbine>
            {
                new Turbine(1, 2, 15, "A"),
                new Turbine(2, 2, 5, "B"),
                new Turbine(3,6, 5, "C"),
                new Turbine(4, 6, 5, "D"),
                new Turbine(5, 5, 3, "E"),
                
            };
        }

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
