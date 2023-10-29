using CollisiumApp.Configs;
using CollisiumApp.Players;
using CollisiumApp.Services;
using CollisiumApp.Utilities;
using CollisiumCore.Interfaces;
using CollisiumCore.Models;
using CollisiumDataAccess.DbContexts;
using CollisiumDataAccess.Repositories;
using CollisiumDataAccess.Services;
using CollisiumStrategies.strategies;
using Microsoft.EntityFrameworkCore;

class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.Configure<ExperimentConfig>(hostContext.Configuration.GetSection("ExperimentConfig"));
                services.AddDbContext<ExperimentDbContext>(options =>
                    options.UseSqlite(hostContext.Configuration.GetConnectionString("DefaultConnection")));
                
                services.AddHostedService<ExperimentWorker>();
                services.AddScoped<Sandbox>();
                services.AddScoped<Deck>();
                services.AddScoped<IDeckShuffler, DeckShuffler>();
                
                services.AddScoped<ICardPickStrategy, ElonStrategy>();
                services.AddScoped<ICardPickStrategy, MarkStrategy>();
                services.AddScoped<ElonPlayer>();
                services.AddScoped<MarkPlayer>();

                services.AddScoped<ExperimentData>();
                services.AddScoped<ExperimentRepository>();
            });
    }
}