using TimeKeeper.Business.DTOs;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Business.Services.Abstractions;

public interface IRaceService
{
    public Task NewRace(string name, CancellationToken cancellationToken);
    public Task<Race> GetRaceByName(string name, CancellationToken cancellationToken);
    public Task AddStage(StageDto stageDto, CancellationToken cancellationToken);
    public Task<ICollection<Stage>> GetStagesOnRace(string raceName, CancellationToken cancellationToken);
}