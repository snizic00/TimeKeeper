namespace TimeKeeper.Domain.Models;

public class Stage
{
    public Stage(ushort id, string name, ushort raceId)
    {
        Id = id;
        Name = name;
        RaceId = raceId;
    }

    public ushort Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public ushort RaceId { get; private set; }
    public ICollection<Result> StageResults { get; private set; } = new List<Result>();
    public Race? Race { get; private set; }
}
