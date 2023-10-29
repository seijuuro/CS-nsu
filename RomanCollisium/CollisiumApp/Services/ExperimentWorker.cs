using CollisiumApp.Configs;
using CollisiumApp.Utilities;
using CollisiumDataAccess.Services;
using Microsoft.Extensions.Options;

namespace CollisiumApp.Services;

public class ExperimentWorker : IHostedService
{
    private readonly Sandbox _sandbox;
    private readonly IOptions<ExperimentConfig> _config;
    private readonly ExperimentData _experimentData;

    public ExperimentWorker(Sandbox sandbox, IOptions<ExperimentConfig>  config, ExperimentData experimentData)
    {
        _config = config;
        _sandbox = sandbox;
        _experimentData = experimentData;
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        int successCount = 0;
        for (int i = 0; i < _config.Value.ExperimentsToRunCount; i++)
        {
            if (_sandbox.RunRandomExperiment())
                successCount++;
        }
        Console.WriteLine($"{successCount} / {_config.Value.ExperimentsToRunCount} = " +
                          $"{(double)successCount / _config.Value.ExperimentsToRunCount}");

        if (_config.Value.GenerateExperimentsDb)
        {
             _experimentData.GenerateAndSave(new DeckShuffler(), _config.Value.ExperimentsDbCount);
        }

        if (_config.Value.RunExperimentsDb)
        {
            var experiments = _experimentData.GetAllData();
            var count = experiments.Count(condition => _sandbox.RunExperiment(condition.CardsOrder));
            Console.WriteLine($"DB: {count} /  {experiments.Count}");
        }
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}