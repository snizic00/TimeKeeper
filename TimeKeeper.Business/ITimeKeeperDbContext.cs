using Microsoft.EntityFrameworkCore;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Business;

public interface ITimeKeeperDbContext
{
    public DbSet<Admin> Admins { get; }
    public DbSet<Bicycle> Bicycles { get; }
    public DbSet<Competitor> Competitors { get; }
    public DbSet<Race> Races { get; }
    public DbSet<Result> Results { get; }
    public DbSet<Stage> Stages { get; }
    public DbSet<Team> Teams { get; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}