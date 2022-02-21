namespace TimeKeeper.Domain.Models;

public class Race
{
    public Race(ushort id, string name)
    {
        Id = id;
        Name = name;
    }

    public ushort Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public ICollection<Stage> Stages { get; private set; } = new List<Stage>();
}
