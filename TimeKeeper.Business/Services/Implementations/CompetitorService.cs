using Microsoft.EntityFrameworkCore;
using TimeKeeper.Business.DTOs;
using TimeKeeper.Business.Services.Enumerations;
using TimeKeeper.Business.Exceptions;
using TimeKeeper.Business.Services.Abstractions;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Business.Services.Implementations;

public class CompetitorService : ICompetitorService
{
    private readonly ITimeKeeperDbContext _dbContext;

    public CompetitorService(ITimeKeeperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddCompetitor(CompetitorDto competitorDto, CompetitorCategory category, CancellationToken cancellationToken)
    {
        if (await Exists(competitorDto.StartNo))
        {
            throw new AlreadyExistsException($"Competitor with start number {competitorDto.StartNo} already exists!");
        }

        Competitor competitor = category switch
        {
            CompetitorCategory.Female => new Female(
                id: default,
                name: competitorDto.Name,
                startNo: competitorDto.StartNo,
                teamId: competitorDto.TeamId,
                bicycleId: competitorDto.BicycleId),

            CompetitorCategory.Male => new Male(
                id: default,
                name: competitorDto.Name,
                startNo: competitorDto.StartNo,
                teamId: competitorDto.TeamId,
                bicycleId: competitorDto.BicycleId),

            _ => throw new NotImplementedException()
        };

        _dbContext.Competitors.Add(competitor);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task<bool> Exists(ushort startNo)
    {
        return await _dbContext.Competitors.AnyAsync(n => n.StartNo == startNo);
    }

    public async Task<IEnumerable<CompetitorDetailsDto>> GetCompetitors(CancellationToken cancellationToken)
    {
        var competitors = await _dbContext.Competitors.AsNoTracking().Select(CompetitorDetailsDto.Projection).ToListAsync(cancellationToken);

        return competitors;
    }

    public async Task<Competitor> FindCompetitorByStartNo(ushort startNo, CancellationToken cancellationToken)
    {
        var competitor = await _dbContext.Competitors.FirstOrDefaultAsync(c => c.StartNo == startNo, cancellationToken);

        return competitor is null ? throw new NotFoundException($"Competitor with start number {startNo} was not found!") : competitor;
    }

    public async Task RemoveCompetitor(ushort startNo, CancellationToken cancellationToken)
    {
        var competitor = await FindCompetitorByStartNo(startNo, cancellationToken);
        _dbContext.Competitors.Remove(competitor);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }


    public async Task NewTeam(string name, CancellationToken cancellationToken)
    {
        var team = new Team(default, name);
        _dbContext.Teams.Add(team);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

}
