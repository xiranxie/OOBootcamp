using System.Collections.Generic;
using System.ComponentModel;

namespace OOBootcamp;

public class Parking
{
    private int _availableSpace;
    private readonly int _maxCapacity;
    private readonly bool _handicappedFriendly;
    private readonly string _name;
    private readonly ISet<string> _slots;

    public event CapacityChangeEvent? CapacityChange;

    public Parking(int maxCapacity, bool handicappedFriendly, string name)
    {
        _maxCapacity = maxCapacity;
        _availableSpace = maxCapacity;
        _handicappedFriendly = handicappedFriendly;
        _slots = new HashSet<string>();
        _name = name;
    }

    public bool Add(string licensePlate)
    {
        if (!IsParkable(licensePlate))
        {
            return false;
        }

        return AddVehicle(licensePlate);
    }

    private bool IsParkable(string licensePlate)
    {
        return !IsFullParking() && !IsPresent(licensePlate);
    }

    private bool AddVehicle(string licensePlate)
    {
        var previousCapacity = _availableSpace;
        _slots.Add(licensePlate);
        _availableSpace--;
        var eventAfter = new ParkingCapacityChangeEvent(_maxCapacity, _availableSpace, previousCapacity, this);
        CapacityChange?.Invoke(this, eventAfter);
        return true;
    }

    private bool IsFullParking()
    {
        return _availableSpace <= 0;
    }

    public int GetAvailableSpace()
    {
        return this._availableSpace;
    }

    public bool RetrieveVehicle(string licensePlate)
    {
        if (!IsPresent(licensePlate))
        {
            return false;
        }
        else
        {
            _slots.Remove(licensePlate);
            _availableSpace++;
            return true;
        }
    }

    public bool IsPresent(string licensePlate)
    {
        return _slots.Contains(licensePlate);
    }

    public void AddPropertyChangeListener(CapacityChangeEvent capacityChangeEvent)
    {
        CapacityChange += capacityChangeEvent;
    }

    public bool IsHandicappedFriendly()
    {
        return _handicappedFriendly;
    }

    public int GetMaxCapacity()
    {
        return _maxCapacity;
    }

    public string GetName()
    {
        return _name;
    }
}

public delegate void CapacityChangeEvent(object sender, ParkingCapacityChangeEvent args);