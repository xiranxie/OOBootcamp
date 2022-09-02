using OOBootcamp;
using OOBootcamp.Strategy;

public class HandicappedVehicleParkStrategy : IParkStrategy
{
    private Vehicle _vehicle;
    private readonly List<Parking> _parkingList;

    public HandicappedVehicleParkStrategy(Vehicle vehicle, List<Parking> parkingList)
    {
        _vehicle = vehicle;
        _parkingList = parkingList;
    }

    public bool Park(Vehicle vehicle, List<Parking> parkingList)
    {
        bool success = false;
        foreach (var parking in _parkingList)
        {
            if (parking.IsHandicappedFriendly() && !success)
            {
                success = parking.Add(vehicle.LicensePlate);
            }
        }
        return success;
    }
}