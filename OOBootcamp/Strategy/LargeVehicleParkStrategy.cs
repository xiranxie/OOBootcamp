namespace OOBootcamp.Strategy;

public class LargeVehicleParkStrategy : IParkStrategy
{
    private Vehicle _vehicle;
    private List<Parking> _parkingList;
    private readonly Dictionary<Parking, Double> _parkingOccupancies = new();


    public LargeVehicleParkStrategy(Vehicle vehicle, List<Parking> parkingList)
    {
        _vehicle = vehicle;
        _parkingList = parkingList;
    }

    private Parking AssembleParkingOccupancies(List<Parking> parkingList)
    {
        foreach (var parking in parkingList)
        {
            _parkingOccupancies[parking] = (parking.GetMaxCapacity() - parking.GetAvailableSpace()) * 1.0 /
                parking.GetMaxCapacity() * 100;
        }

        return _parkingOccupancies.MinBy(kvp => kvp.Value).Key;
    }

    public bool Park(Vehicle vehicle, List<Parking> parkingList)
    {
        var min = AssembleParkingOccupancies(parkingList);
        min.Add(vehicle.LicensePlate);
        return true;
    }
}