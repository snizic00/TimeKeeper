using TimeKeeper.Business.DTOs;
using TimeKeeper.Business.Services.Enumerations;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Business.Services.Abstractions;

public interface ICompetitorService
{
    public Task AddCompetitor(CompetitorDto competitorDto, CompetitorCategory category, CancellationToken cancellationToken);
    public Task<IEnumerable<CompetitorDetailsDto>> GetCompetitors(CancellationToken cancellationToken);
    public Task<Competitor> FindCompetitorByStartNo(ushort startNo, CancellationToken cancellationToken);
    public Task RemoveCompetitor(ushort startNo, CancellationToken cancellationToken);
    public Task NewTeam(string name, CancellationToken cancellationToken);

}
