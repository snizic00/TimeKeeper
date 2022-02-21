namespace TimeKeeper.Domain.Models;

public class Result
{
    public Result(ushort id, ushort competitorId, ushort stageId, TimeSpan stageTime)
    {
        Id = id;
        CompetitorId = competitorId;
        StageId = stageId;
        StageTime = stageTime;
    }

    public ushort Id { get; private set; }
    public ushort CompetitorId { get; private set; }
    public ushort StageId { get; private set; }
    public TimeSpan StageTime { get; private set; }
    public Competitor? Competitor { get; private set; }
    public Stage? Stage { get; private set; }
}
