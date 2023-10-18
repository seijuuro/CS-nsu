using CollisiumApp.Players;
using CollisiumApp.Services;
using CollisiumApp.Utilities;
using CollisiumCore.Interfaces;
using CollisiumCore.Models;
using CollisiumStrategies.strategies;

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
                services.AddHostedService<CollisiumExperimentWorker>();
                services.AddScoped<CollisiumSandbox>();
                services.AddScoped<Deck>();
                services.AddScoped<IDeckShuffler, DeckShuffler>();
                
                // Зарегистрировать партнеров и их стратегии
                services.AddScoped<ICardPickStrategy, ElonStrategy>();
                services.AddScoped<ICardPickStrategy, MarkStrategy>();
                services.AddScoped<ElonPlayer>();
                services.AddScoped<MarkPlayer>();

            });
    }
}