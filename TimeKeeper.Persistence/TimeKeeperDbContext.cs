using Microsoft.EntityFrameworkCore;
using TimeKeeper.Business;
using TimeKeeper.Domain.Models;
using TimeKeeper.Persistence.Configurations;

namespace TimeKeeper.Persistence;

public class TimeKeeperDbContext : DbContext, ITimeKeeperDbContext
{
    public TimeKeeperDbContext(DbContextOptions<TimeKeeperDbContext> options) : base(options)
    {
    }
    public DbSet<Admin> Admins { get; set; } = null!;
    public DbSet<Bicycle> Bicycles { get; set; } = null!;
    public DbSet<Competitor> Competitors { get; set; } = null!;
    public DbSet<Race> Races { get; set; } = null!;
    public DbSet<Result> Results { get; set; } = null!;
    public DbSet<Stage> Stages { get; set; } = null!;
    public DbSet<Team> Teams { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _ = modelBuilder.ApplyConfiguration(new AdminConfiguration());
        _ = modelBuilder.ApplyConfiguration(new CompetitorConfiguration());
        _ = modelBuilder.ApplyConfiguration(new RaceConfiguration());
        _ = modelBuilder.ApplyConfiguration(new StageConfiguration());
        _ = modelBuilder.ApplyConfiguration(new TeamConfiguration());
    }
}