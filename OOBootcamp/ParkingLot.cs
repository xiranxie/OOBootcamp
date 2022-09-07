namespace OOBootcamp;

public class ParkingLot
{
    public string Name { get; }
    public double HourlyRate { get; }
    public int AvailableCount { get; private set; }
    public int MaxCapacity { get; }
    private readonly Dictionary<Vehicle, DateTime> _parkedVehicles;

    public ParkingLot(int maxCapacity, double hourlyRate, string name)
    {
        MaxCapacity = maxCapacity;
        Name = name;
        HourlyRate = hourlyRate;
        AvailableCount = maxCapacity;
        _parkedVehicles = new Dictionary<Vehicle, DateTime>();
    }
    
    public bool ParkVehicle(Vehicle vehicle)
    {
        if (AvailableCount > 0)
        {
            _parkedVehicles.Add(vehicle, DateTime.UtcNow);
            AvailableCount--;
            return true;
        }

        return false;
    }

    public bool HasVehicle(Vehicle vehicle)
    {
        return _parkedVehicles.ContainsKey(vehicle);
    }
    
    public double RetrieveVehicle(Vehicle vehicle)
    {
        if (_parkedVehicles.ContainsKey(vehicle))
        {
            return Math.Ceiling((DateTime.UtcNow - _parkedVehicles[vehicle]).TotalMilliseconds / 3600.0) * HourlyRate;
        }

        throw new VehicleNotFoundException(vehicle);
    }
}