using Microsoft.EntityFrameworkCore;
using TimeKeeper.Domain.Models;
using TimeKeeper.Persistence;

var context = TimeKeeperDbContextFactory.Create(args);

var races = new List<Race> {
    new Race(default, "Split"),
    new Race(default, "Trogir")
    };

await context.Races.AddRangeAsync(races);
await context.SaveChangesAsync();

var race1 = await context.Races.FirstAsync(i => i.Name == "Split");
var race1Stages = new List<Stage>{
    new Stage(default,"S1", default),
    new Stage(default, "S2", default),
    new Stage(default, "S3", default),
    new Stage(default, "S4", default)
};
race1Stages.ForEach(s => race1.Stages.Add(s));
await context.SaveChangesAsync();

var race2 = await context.Races.FirstAsync(i => i.Name == "Trogir");
var race2Stages = new List<Stage>{
    new Stage(default,"S5",default),
    new Stage(default,"S6",default),
    new Stage(default,"S7",default)
};
race2Stages.ForEach(s => race2.Stages.Add(s));
await context.SaveChangesAsync();

await context.Teams.AddRangeAsync(
    new Team(default, "team1"),
    new Team(default, "team2")
);
await context.SaveChangesAsync();

var competitorsF = new List<Female>{
    new Female(default, "Melyssa Chaneys", 4, 1, default),
    new Female(default, "Lilah Alvarez", 1, default, default),
    new Female(default, "Mary Mack", 3, 2, default)
};
await context.Competitors.AddRangeAsync(competitorsF);
await context.SaveChangesAsync();

var competitorsM = new List<Male>{
    new Male(default, "Jerome Daniels", 5, default, default),
    new Male(default, "Orson Olson", 2, 1, default),
    new Male(default, "Asher Masse", 6, 1, default)
};
await context.Competitors.AddRangeAsync(competitorsM);
await context.SaveChangesAsync();

var rider1 = await context.Competitors.FirstAsync(n => n.StartNo == 3);
var rider1Results = new List<Result>{
    new Result(default, default, 1, TimeSpan.Parse("00:01:34.522")),
    new Result(default, default, 2, TimeSpan.Parse("00:01:27.630")),
    new Result(default, default, 3, TimeSpan.Parse("00:03:40.733")),
    new Result(default, default, 4, TimeSpan.Parse("00:02:56.821"))
};
rider1Results.ForEach(r => rider1.MyResults.Add(r));
await context.SaveChangesAsync();

var women = await context.Competitors.OfType<Female>().ToListAsync();
var men = await context.Competitors.OfType<Male>().ToListAsync();

var rider1Data = await context.Races.Join(context.Stages,
                                        race => race.Id, stage => stage.RaceId,
                                        (races, stages) => new
                                        {
                                            races,
                                            stages
                                        })
                                    .Join(context.Results,
                                        stage => stage.stages.Id, results => results.StageId,
                                        (first, results) => new
                                        {
                                            id = results.CompetitorId,
                                            stageId = results.StageId,
                                            stageName = first.stages.Name,
                                            time = results.StageTime
                                        })
                                    .Where(rider => rider.id == 3).ToListAsync();

var totalTimeLong = rider1Data.Select(stage => stage.time.Ticks).Sum();
var rider1TotalTime = new TimeSpan(totalTimeLong);

var teamRiders = await context.Competitors.Join(context.Teams,
                                                c => c.TeamId, t => t.Id,
                                                (comp, team) => new
                                                {
                                                    riderName = comp.Name,
                                                    startNo = comp.StartNo,
                                                    team = team.Name
                                                })
                                            .Where(t => t.team == "team1").ToListAsync();
