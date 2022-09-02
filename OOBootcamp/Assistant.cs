using System.Collections.Generic;
using System.Linq;

namespace OOBootcamp;

public class Assistant : IParkingAssistant
{
    private readonly Dictionary<Parking, double> _parkingOccupancies = new();
    private IParkingAssistant _parkingAssistant;
    private readonly string _name;

    public Assistant(List<Parking> parkingList, string name)
    {
        foreach (var parking in parkingList)
        {
            parking.AddPropertyChangeListener(PropertyChange);
            _parkingOccupancies[parking] = 0.0;
        }

        _name = name;
    }

    public Assistant()
    {
        _name = "Default Name";
    }


    public bool ParkVehicle(Vehicle vehicle)
    {
        var parked = false;
        if (_parkingAssistant != null)
        {
            parked = _parkingAssistant.ParkVehicle(vehicle);
        }

        if (!parked)
        {
            var parkingList = _parkingOccupancies.Keys.ToList();
            var parkStrategy = vehicle.SelectParkStrategy(parkingList);
            parked = parkStrategy.Park(vehicle, parkingList);
        }

        return parked;
    }


    public string GetName()
    {
        return _name;
    }

    public bool RetrieveVehicle(string licensePlate)
    {
        var parkingList = _parkingOccupancies.Keys.ToList();
        var success = false;
        foreach (var parking in parkingList.Where(parking => parking.IsPresent(licensePlate)))
        {
            success = parking.RetrieveVehicle(licensePlate);
        }

        return success;
    }


    private void PropertyChange(object sender, ParkingCapacityChangeEvent evt)
    {
        _parkingOccupancies[evt.GetParking()] = evt.GetPercentageOfOccupancy();
    }

    public double GetCapacity(Parking parking)
    {
        return this._parkingOccupancies[parking];
    }

    public void SetParkingAssistant(IParkingAssistant parkingAssistant)
    {
        this._parkingAssistant = parkingAssistant;
    }
}