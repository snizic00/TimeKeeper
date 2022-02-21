using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using TimeKeeper.Business;
using TimeKeeper.Business.Services.Abstractions;
using TimeKeeper.Business.Services.Implementations;
using TimeKeeper.Persistence;

namespace TimeKeeper.WebApi;

internal sealed partial class Startup
{
    private readonly IConfiguration _configuration;
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Configures Applications DI IoC Container.
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {


        services.AddCors(c =>
        {
            c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        });

        _ = services.AddScoped<ICompetitorService, CompetitorService>();
        _ = services.AddScoped<IRaceService, RaceService>(); 

        _ = services.AddControllers();

        _ = services.AddDbContext<ITimeKeeperDbContext, TimeKeeperDbContext>(dbContextOptionsBuilder =>
         {
             _ = dbContextOptionsBuilder.UseSqlServer(ConfigurationExtensions.GetConnectionString(_configuration, "LocalDatabase"));
         });

        services.AddSpaStaticFiles(configuration => configuration.RootPath = "../client/build");

        services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
            .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
            = new DefaultContractResolver());
    }

    /// <summary>
    /// Configures Application Middleware.
    /// </summary>
    /// <param name="app"></param>
    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        _ = app.UseRouting();

        app.UseStaticFiles();
        app.UseSpaStaticFiles();

        app.UseSpa(spa =>
        {
            spa.Options.SourcePath = Path.Join(env.ContentRootPath, "../client");
        });

        _ = app.UseEndpoints(endpoints =>
        {
            _ = endpoints.MapControllers();
        });
    }
}
