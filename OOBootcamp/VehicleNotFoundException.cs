namespace OOBootcamp;

public class VehicleNotFoundException : Exception
{
    private Vehicle _missiongVehicle;
    public VehicleNotFoundException(Vehicle vehicle)
    {
        _missiongVehicle = vehicle;
    }
}