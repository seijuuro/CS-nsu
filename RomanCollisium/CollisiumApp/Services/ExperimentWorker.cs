using CollisiumDataAccess.Services;
using Core.Configs;
using Core.Services;
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
        var successCount = 0;
        for (var i = 0; i < _config.Value.ExperimentsToRunCount; i++)
        {
            if (_sandbox.RunRandomExperiment())
                successCount++;
        }
        Console.WriteLine($"{successCount} / {_config.Value.ExperimentsToRunCount} = " +
                          $"{(double)successCount / _config.Value.ExperimentsToRunCount}");

        if (_config.Value.GenerateExperimentsDb)
        {
            var elonStrategyName = _sandbox.GetElonStrategyName();
            var markStrategyName = _sandbox.GetMarkStrategyName();
             _experimentData.SaveRandomExperiment(elonStrategyName, markStrategyName,
                 _config.Value.ExperimentsDbCount, _config.Value.DeckSize);
        }

        if (_config.Value.RunExperimentsDb)
        {
            var experiments = _experimentData.GetAllConditions();
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