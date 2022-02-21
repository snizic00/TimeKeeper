namespace TimeKeeper.Domain.Models;

public class Competitor
{
    public Competitor(ushort id, string name, ushort startNo, ushort? teamId, ushort? bicycleId)
    {
        Id = id;
        Name = name;
        StartNo = startNo;
        TeamId = teamId;
        BicycleId = bicycleId;
    }
    public ushort Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public ushort StartNo { get; private set; }
    public ushort? TeamId { get; private set; }
    public ushort? BicycleId { get; set; }
    public Team? Team { get; private set; }
    public Bicycle? Bicycle { get; private set; }
    public ICollection<Result> MyResults { get; private set; } = new List<Result>();
}
