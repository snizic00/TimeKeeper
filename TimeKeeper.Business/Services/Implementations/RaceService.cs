using Microsoft.EntityFrameworkCore;
using TimeKeeper.Business.DTOs;
using TimeKeeper.Business.Exceptions;
using TimeKeeper.Business.Services.Abstractions;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Business.Services.Implementations;
public class RaceService : IRaceService
{
    private readonly ITimeKeeperDbContext _dbContext;

    public RaceService(ITimeKeeperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task NewRace(string name, CancellationToken cancellationToken)
    {
        var race = new Race(
            id: default,
            name: name);
        _dbContext.Races.Add(race);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Race> GetRaceByName(string name, CancellationToken cancellationToken)
    {
        var race = await _dbContext.Races.FirstOrDefaultAsync(r => r.Name == name, cancellationToken);

        return race is null ? throw new NotFoundException($"No race named \"{name}\" was found") : race;
    }

    public async Task AddStage(StageDto stageDto, CancellationToken cancellationToken)
    {
        var stage = new Stage(
            id: default,
            name: stageDto.Name,
            raceId: stageDto.RaceId);

        _dbContext.Stages.Add(stage);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<ICollection<Stage>> GetStagesOnRace(string raceName, CancellationToken cancellationToken)
    {
        var race = await GetRaceByName(raceName, default);
        var stages = await _dbContext.Stages.AsNoTracking().Where(r => r.RaceId == race.Id).ToListAsync(cancellationToken);
        return stages;
    }
}