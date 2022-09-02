namespace OOBootcamp.Strategy;

public interface IParkStrategy
{
    bool Park(Vehicle vehicle, List<Parking> parkingList);
}