using CollisiumApp.Services;
using CollisiumDataAccess.DbContexts;
using CollisiumDataAccess.Entities;
using CollisiumDataAccess.Repositories;
using CollisiumDataAccess.Services;
using Core.Configs;
using Core.Interfaces;
using Core.Models;
using Core.Players;
using Core.Services;
using Core.Strategies;
using Core.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CollisiumApp;

static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.Configure<ExperimentConfig>(hostContext.Configuration.GetSection("ExperimentConfig"));
                IServiceProvider serviceProvider = services.BuildServiceProvider();
                
                services.AddDbContext<ExperimentDbContext>(options =>
                    options.UseSqlite(hostContext.Configuration.GetConnectionString("DefaultConnection")));
                
                services.AddHostedService<ExperimentWorker>();
                services.AddScoped<Sandbox>();
                services.AddScoped<Deck>(_ => 
                    new Deck(serviceProvider.GetRequiredService<IOptions<ExperimentConfig>>().Value.DeckSize));
                
                services.AddScoped<IDeckShuffler, DeckShuffler>();
                services.AddScoped<IElonStrategy, PickFirstRedStrategy>();
                services.AddScoped<IMarkStrategy, PickFirstRedStrategy>();
                services.AddScoped<ElonPlayer>();
                services.AddScoped<MarkPlayer>();

                services.AddScoped<ExperimentData>();
                services.AddScoped<ExperimentRepository>();
            });
    }
}