using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace OOBootcamp.Test;

public class GraduateBoyTest
{
    private GraduateParkingBoy _graduateParkingBoy;
    private LinkedList<ParkingLot> _parkingLots;
    

    [Test]
    public void Should_Park_In_A_When_Parking_Given_A_Is_Not_Full()
    {
        var parkingLots = new List<ParkingLot>
        {
            new(2, 5, "A"),
            new(2, 5, "B")
        };
        _parkingLots = new LinkedList<ParkingLot>(parkingLots);
        _graduateParkingBoy = new GraduateParkingBoy(_parkingLots);
        var vehicle = new Vehicle("123");
        var parkingLot = _graduateParkingBoy.Park(vehicle);
        Assert.AreEqual("A",parkingLot.Name);
    }
    

    [Test]
    public void Should_Park_In_A_And_B_When_Parking_Given_Two_Vehicles()
    {
        var parkingLots = new List<ParkingLot>
        {
            new(2, 5, "A"),
            new(2, 5, "B")
        };
        _parkingLots = new LinkedList<ParkingLot>(parkingLots);
        _graduateParkingBoy = new GraduateParkingBoy(_parkingLots);
        var vehicle1 = new Vehicle("123");
        var vehicle2 = new Vehicle("456");
        var parkingLot1 = _graduateParkingBoy.Park(vehicle1);
        var parkingLot2 = _graduateParkingBoy.Park(vehicle2);
        Assert.AreEqual("A",parkingLot1.Name);
        Assert.AreEqual("B",parkingLot2.Name);
    }


    [Test]
    public void Should_Park_In_A_And_B_And_A_When_Parking_Given_Three_Vehicles()
    {
        var parkingLots = new List<ParkingLot>
        {
            new(2, 5, "A"),
            new(2, 5, "B")
        };
        _parkingLots = new LinkedList<ParkingLot>(parkingLots);
        _graduateParkingBoy = new GraduateParkingBoy(_parkingLots);
        var vehicle1 = new Vehicle("123");
        var vehicle2 = new Vehicle("456");
        var vehicle3 = new Vehicle("789");
        var parkingLot1 = _graduateParkingBoy.Park(vehicle1);
        var parkingLot2 = _graduateParkingBoy.Park(vehicle2);
        var parkingLot3 = _graduateParkingBoy.Park(vehicle3);
        Assert.AreEqual("A",parkingLot1.Name);
        Assert.AreEqual("B",parkingLot2.Name);
        Assert.AreEqual("A",parkingLot3.Name);
    }

    [Test]
    public void Should_Park_In_A_B_B_When_Parking_Given_A_Can_Only_Park_One_Vehicle()
    {
        var parkingLots = new List<ParkingLot>
        {
            new(1, 5, "A"),
            new(2, 5, "B")
        };
        _parkingLots = new LinkedList<ParkingLot>(parkingLots);
        _graduateParkingBoy = new GraduateParkingBoy(_parkingLots);
        var vehicle1 = new Vehicle("123");
        var vehicle2 = new Vehicle("456");
        var vehicle3 = new Vehicle("789");
        var parkingLot1 = _graduateParkingBoy.Park(vehicle1);
        var parkingLot2 = _graduateParkingBoy.Park(vehicle2);
        var parkingLot3 = _graduateParkingBoy.Park(vehicle3);
        Assert.AreEqual("A",parkingLot1.Name);
        Assert.AreEqual("B",parkingLot2.Name);
        Assert.AreEqual("B",parkingLot3.Name);
    }
    
    [Test]
    public void Should_Throw_Exception_When_Parking_3TH_Vehicle_Given_Three_Vehicles()
    {
        var parkingLots = new List<ParkingLot>
        {
            new(1, 5, "A"),
            new(1, 5, "B")
        };
        _parkingLots = new LinkedList<ParkingLot>(parkingLots);
        _graduateParkingBoy = new GraduateParkingBoy(_parkingLots);
        var vehicle1 = new Vehicle("123");
        var vehicle2 = new Vehicle("456");
        var vehicle3 = new Vehicle("789");
        var parkingLot1 = _graduateParkingBoy.Park(vehicle1);
        var parkingLot2 = _graduateParkingBoy.Park(vehicle2);
        Assert.AreEqual("A",parkingLot1.Name);
        Assert.AreEqual("B",parkingLot2.Name);
        var exception = Assert.Throws<Exception>(() => _graduateParkingBoy.Park(vehicle3));
        Assert.AreEqual("all full", exception.Message);
    }


}