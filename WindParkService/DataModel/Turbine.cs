namespace WindParkService.DataModel;

public class Turbine
{
    public Turbine(int id, float maxCapacity, float productionCost, string name)
    {
        Id = id;
        MaxCapacity = maxCapacity;
        ProductionCost = productionCost;
        Name = name;
    }

    public int Id { get; private set; }
    public float MaxCapacity { get; private set; }
    public float ProductionCost { get; private set; }
    public string Name { get; private set; }
    public bool IsRunning { get; set; } = false;

    public void Start()
    {
        // Logic to start the turbine
        IsRunning = true;
    }

    public void Stop()
    {
        // Logic to stop the turbine
        IsRunning = false;
    }
}