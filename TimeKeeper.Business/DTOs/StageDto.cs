namespace TimeKeeper.Business.DTOs;
public class StageDto
{
    public StageDto(string name, ushort raceId)
    {
        Name = name;
        RaceId = raceId;
    }

    public string Name { get; }
    public ushort RaceId { get; }
}