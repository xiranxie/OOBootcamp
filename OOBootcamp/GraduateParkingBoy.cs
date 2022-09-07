namespace OOBootcamp;

public class GraduateParkingBoy
{
    // Write your logic here
    private readonly LinkedList<ParkingLot> _parkingLots;

    public GraduateParkingBoy(LinkedList<ParkingLot> parkingLots)
    {
        _parkingLots = parkingLots;
    }

    public ParkingLot Park(Vehicle vehicle)
    {
        var parkingLotNode = _parkingLots.First;
        if (parkingLotNode.Value.ParkVehicle(vehicle))
        {
            return parkingLotNode.Value;
        }

        var nextParkingLot = parkingLotNode.Next.Value;
        if (nextParkingLot.ParkVehicle(vehicle))
        {
            return nextParkingLot;
        }

        throw new Exception("all full");

    }
}