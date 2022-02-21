namespace TimeKeeper.Domain.Models;

public class Male : Competitor
{
    public Male(ushort id, string name, ushort startNo, ushort? teamId, ushort? bicycleId) : base(id, name, startNo, teamId, bicycleId)
    {
    }
}
