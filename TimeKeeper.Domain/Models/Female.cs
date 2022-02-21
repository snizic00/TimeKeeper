namespace TimeKeeper.Domain.Models;

public class Female : Competitor
{
    public Female(ushort id, string name, ushort startNo, ushort? teamId, ushort? bicycleId) : base(id, name, startNo, teamId, bicycleId)
    {
    }
}
