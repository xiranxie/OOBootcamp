namespace OOBootcamp;

public class GraduateParkingBoy
{
    // Write your logic here
    private readonly LinkedList<ParkingLot> _parkingLots;
    private LinkedListNode<ParkingLot> _currentParkingLotNode;

    public GraduateParkingBoy(LinkedList<ParkingLot> parkingLots)
    {
        _parkingLots = parkingLots;
        _currentParkingLotNode = parkingLots.First;
    }

    public ParkingLot Park(Vehicle vehicle)
    {
        var parkingLotNode = _currentParkingLotNode;
        if (parkingLotNode.Value.ParkVehicle(vehicle))
        {
            _currentParkingLotNode = parkingLotNode.Next;
            return parkingLotNode.Value;
        }
        _currentParkingLotNode = parkingLotNode.Next;
        Park(vehicle);
        return new ParkingLot(0,0,"test");

    }
}