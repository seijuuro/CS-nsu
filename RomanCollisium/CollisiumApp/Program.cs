using CollisiumApp;
using CollisiumStrategies;

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
                services.AddScoped<IDeckShufller, DeckShufller>();
                
                // Зарегистрировать партнеров и их стратегии
                services.AddScoped<ElonStrategy>();
                services.AddScoped<MarkStrategy>();
                services.AddScoped<ElonPlayer>();
                services.AddScoped<MarkPlayer>();

            });

    }
}