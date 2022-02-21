namespace TimeKeeper.WebApi;

/// <summary>
///
/// </summary>
internal static class Program
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="args"></param>
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(configureOptions =>
            {
                var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty;

                _ = configureOptions
                    .AddJsonFile(path: $"appsettings.json", optional: false)
                    .AddJsonFile(path: $"appsettings.{environmentName}.json", optional: false)
                    .AddEnvironmentVariables()
                    .Build();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                _ = webBuilder.UseStartup<Startup>();
                _ = webBuilder.ConfigureLogging(loggingBuilder =>
                  {
                      _ = loggingBuilder.ClearProviders();
                      _ = loggingBuilder.AddConsole();
                  });
            });
}
