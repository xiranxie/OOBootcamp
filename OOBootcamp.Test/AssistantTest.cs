using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace OOBootcamp.Test;

public class AssistantTest
{
    private static string LICENSE_PLATE = "MAT-001";
    public static string LICENSE_PLATE_TEST = "M-1";
    public static double DELTA_ERROR_MARGIN = 0.01;
    public static string NAME_TEST = "Pepe Perez";
    private Assistant _assistant;
    private Parking _parking;
    private Parking _parkingOther;
    private List<Parking> _parkingList;


    [SetUp]
    public void SetUp()
    {
        // initMocks(this);
        _parking = new Parking(1, false, "Parking Callao");
        _parkingOther = new Parking(10, false, "Parking Callao");
        _parkingList = new List<Parking>
        {
            _parking,
            _parkingOther
        };
        _assistant = new Assistant(_parkingList, NAME_TEST);
    }

    [Test]
    public void ItShouldParkVehicleInFirstParkingWithSpace()
    {
        var parkingFull = new Parking(0, false, "Parking Callao");
        var parkingAvailable = new Parking(2, false, "Parking Callao");
        var parkingList = new List<Parking> { parkingFull, parkingAvailable };
        var assistant = new Assistant(parkingList, NAME_TEST);
        Assert.True(assistant.ParkVehicle(new Vehicle(LICENSE_PLATE, false, false)));
    }

    [Test]
    public void ItShouldRetrieveVehicle()
    {
        _assistant.ParkVehicle(new Vehicle(LICENSE_PLATE, false, false));
        Assert.True(_assistant.RetrieveVehicle(LICENSE_PLATE));
        Assert.False(_assistant.RetrieveVehicle(LICENSE_PLATE));
    }

    [Test]
    public void ItShouldParkLargeCarsInParkingWithLeastPercentageOfUsage()
    {
        var assistant = AssembleAssistant(_parking, _parkingOther);

        _parking.Add("M1");

        assistant.ParkVehicle(new Vehicle(LICENSE_PLATE_TEST, true, false));
        Assert.False(_parking.RetrieveVehicle(LICENSE_PLATE_TEST));
        Assert.True(_parkingOther.RetrieveVehicle(LICENSE_PLATE_TEST));
    }

    private Assistant AssembleAssistant(params Parking[] parkings)
    {
        var parkingList = parkings.ToList();
        return new Assistant(parkingList, NAME_TEST);
    }

    [Test]
    public void ItShouldParkHandicappedCarsInParkingForHandicappedCars()
    {
        var parking = new Parking(5, false, "Parking Callao");
        var parkingOther = new Parking(5, true, "Parking Callao");
        var assistant = new Assistant(new List<Parking> { parking, parkingOther }, NAME_TEST);

        assistant.ParkVehicle(new Vehicle(LICENSE_PLATE_TEST, false, true));
        Assert.False(parking.RetrieveVehicle(LICENSE_PLATE_TEST));
        Assert.True(parkingOther.RetrieveVehicle(LICENSE_PLATE_TEST));
    }
}