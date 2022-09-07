namespace OOBootcamp;

public class GraduateParkingBoy
{
    private readonly List<ParkingLot> _parkingLots;
    private int _currentParkingLotIndex;
    private int _fulledParkingLots;

    public GraduateParkingBoy(List<ParkingLot> parkingLots)
    {
        _parkingLots = parkingLots;
        _currentParkingLotIndex = 0;
        _fulledParkingLots = 0;
    }

    public ParkingLot Park(Vehicle vehicle)
    {
        if (_parkingLots.Count == _fulledParkingLots)
        {
            throw new Exception("all full");
        }
        var parkingLot = _parkingLots[_currentParkingLotIndex];
        if (parkingLot.ParkVehicle(vehicle))
        {
            SetCurrentParkingLotNode();
            return parkingLot;
        }
        _fulledParkingLots++;
        SetCurrentParkingLotNode();
        return Park(vehicle);
    }

    private void SetCurrentParkingLotNode()
    {
        _currentParkingLotIndex = (_currentParkingLotIndex+1)% _parkingLots.Count;
    }

    public double Retrieve(Vehicle vehicle)
    {
        return _parkingLots[_currentParkingLotIndex].RetrieveVehicle(vehicle);
    } 
}