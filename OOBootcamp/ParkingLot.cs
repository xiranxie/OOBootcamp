namespace OOBootcamp;

public class ParkingLot
{
    public string Name { get; }
    public double HourlyRate { get; }
    private int MaxCapacity { get; }
    
    private readonly int _availableSpace;
    private readonly Dictionary<Vehicle, DateTime> _parkedVehicles;

    public ParkingLot(int maxCapacity, double hourlyRate, string name)
    {
        MaxCapacity = maxCapacity;
        Name = name;
        HourlyRate = hourlyRate;
        _availableSpace = maxCapacity;
        _parkedVehicles = new Dictionary<Vehicle, DateTime>();
    }
    
    public bool ParkVehicle(Vehicle vehicle)
    {
        if (_availableSpace > 0)
        {
            _parkedVehicles.Add(vehicle, DateTime.UtcNow);
            return true;
        }

        return false;
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