namespace OOBootcamp.Strategy;

public class RegularVehicleParkStrategy : IParkStrategy
{
    private Vehicle _vehicle;
    private readonly List<Parking> _parkingList;
    private readonly Dictionary<Parking, Double> _parkingOccupancies = new();

    public RegularVehicleParkStrategy(Vehicle vehicle, List<Parking> parkingList)
    {
        _vehicle = vehicle;
        _parkingList = parkingList;
    }

    private bool IsOccupiedAt80Percent(int i)
    {
        foreach (var parking in _parkingList)
        {
            _parkingOccupancies[parking] = 0.0;
        }

        var parkingList = _parkingOccupancies.Keys.ToList();
        var occupancy = _parkingOccupancies[parkingList[i]];
        return occupancy < 80;
    }

    public bool Park(Vehicle vehicle, List<Parking> parkingList)
    {
        bool success = false;
        int i = 0;
        while (!success && i < parkingList.Count && IsOccupiedAt80Percent(i))
        {
            success = parkingList[i].Add(vehicle.LicensePlate);
            i++;
        }

        return success;
    }
}