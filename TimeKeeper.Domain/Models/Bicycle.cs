using TimeKeeper.Domain.Enumerations;

namespace TimeKeeper.Domain.Models;

public class Bicycle
{
    public Bicycle(ushort id, BicycleType bicycleType)
    {
        Id = id;
        BicycleType = bicycleType;
    }

    public ushort Id { get; private set; }
    public BicycleType BicycleType { get; private set; }
    public ICollection<Competitor> BicycleOwners { get; private set; } = new List<Competitor>();
}