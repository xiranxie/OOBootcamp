using System.Collections.Generic;
using OOBootcamp.Strategy;

namespace OOBootcamp;

public class Vehicle
{
    public readonly string LicensePlate;
    private readonly bool _large;
    private readonly bool _handicapped;
    private IParkStrategy _parkStrategy; //todo with polymorphism

    public Vehicle(string licensePlate, bool large, bool handicapped)
    {
        LicensePlate = licensePlate;
        _large = large;
        _handicapped = handicapped;
    }

    public IParkStrategy SelectParkStrategy(List<Parking> parkingList)
    {
        _parkStrategy = new RegularVehicleParkStrategy(this, parkingList);
        if (_large)
        {
            _parkStrategy = new LargeVehicleParkStrategy(this, parkingList);
        }
        else if (_handicapped)
        {
            _parkStrategy = new HandicappedVehicleParkStrategy(this, parkingList);
        }

        return _parkStrategy;
    }
}