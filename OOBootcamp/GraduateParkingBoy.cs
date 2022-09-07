namespace OOBootcamp;

public class GraduateParkingBoy
{
    private readonly LinkedList<ParkingLot> _parkingLots;
    private LinkedListNode<ParkingLot> _currentParkingLotNode;
    private int _fulledParkingLots;

    public GraduateParkingBoy(LinkedList<ParkingLot> parkingLots)
    {
        _parkingLots = parkingLots;
        _currentParkingLotNode = parkingLots.First;
        _fulledParkingLots = 0;
    }

    public ParkingLot Park(Vehicle vehicle)
    {
        if (_parkingLots.Count == _fulledParkingLots)
        {
            throw new Exception("all full");
        }
        var parkingLotNode = _currentParkingLotNode;
        if (parkingLotNode.Value.ParkVehicle(vehicle))
        {
            SetCurrentParkingLotNode(parkingLotNode);
            return parkingLotNode.Value;
        }
        _fulledParkingLots++;
        SetCurrentParkingLotNode(parkingLotNode);
        return Park(vehicle);
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