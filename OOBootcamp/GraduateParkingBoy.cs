namespace OOBootcamp;

public class GraduateParkingBoy
{
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
            SetCurrentParkingLotNode(parkingLotNode);
            return parkingLotNode.Value;
        }
        SetCurrentParkingLotNode(parkingLotNode);
        Park(vehicle);
        return new ParkingLot(0,0,"test");
    }

    private void SetCurrentParkingLotNode(LinkedListNode<ParkingLot> parkingLotNode)
    {
        if (parkingLotNode == _parkingLots.Last)
        {
            _currentParkingLotNode = _parkingLots.First;
        }
        else
        {
            _currentParkingLotNode = parkingLotNode.Next;
        }
    }
}