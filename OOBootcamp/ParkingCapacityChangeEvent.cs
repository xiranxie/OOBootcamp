using System;

namespace OOBootcamp;

public class ParkingCapacityChangeEvent : EventArgs
{
    private readonly int _maxCapacity;
    private readonly int _currentCapacity;
    private readonly int _previousCapacity;
    private readonly Parking _parking;

    public ParkingCapacityChangeEvent(int maxCapacity, int currentCapacity, int previousCapacity, Parking parking)
    {
        this._maxCapacity = maxCapacity;
        this._currentCapacity = currentCapacity;
        _previousCapacity = previousCapacity;
        _parking = parking;
    }

    public double GetPercentageOfOccupancy()
    {
        return ((_maxCapacity - _currentCapacity) * 1.0 / _maxCapacity) * 100;
    }

    public Parking GetParking()
    {
        return _parking;
    }
}