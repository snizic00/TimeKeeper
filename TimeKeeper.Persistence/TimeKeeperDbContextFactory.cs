using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace TimeKeeper.Persistence;

public class TimeKeeperDbContextFactory : IDesignTimeDbContextFactory<TimeKeeperDbContext>
{
    public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
    });

    public static TimeKeeperDbContext Create(string[] args)
    {
        if (args.Length != 1)
        {
            throw new ArgumentException("Connection string must be provided as argument!");
        }

        var connectionString = args[0];
        var optionsBuilder = new DbContextOptionsBuilder<TimeKeeperDbContext>();
        _ = optionsBuilder.UseSqlServer(connectionString);
        _ = optionsBuilder.UseLoggerFactory(ConsoleLoggerFactory);

        var dbContext = new TimeKeeperDbContext(optionsBuilder.Options);

        return dbContext;
    }

    public TimeKeeperDbContext CreateDbContext(string[] args)
    {
        return Create(args);
    }
}
