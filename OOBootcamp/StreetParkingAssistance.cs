namespace OOBootcamp;

public class StreetParkingAssistance : IParkingAssistant
{
    public bool ParkVehicle(Vehicle vehicle)
    {
        return true;
    }

    public string GetName()
    {
        return "Street Parking";
    }
}