namespace TimeKeeper.Domain.Models;

public class Team
{
    public Team(ushort id, string name)
    {
        Id = id;
        Name = name;
    }

    public ushort Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public ICollection<Competitor> TeamMembers { get; private set; } = new List<Competitor>();
}
