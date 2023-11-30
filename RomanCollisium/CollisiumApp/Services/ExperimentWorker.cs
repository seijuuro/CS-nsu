using CollisiumDataAccess.Services;
using Core.Configs;
using Core.Players;
using Core.Services;
using Microsoft.Extensions.Options;
using PlayerWebLib;

namespace CollisiumApp.Services;

public class ExperimentWorker : IHostedService
{
    private readonly Sandbox _sandbox;
    private readonly IOptions<ExperimentConfig> _config;
    private readonly ExperimentData _experimentData;
    private readonly PlayerResolver _playerResolver;

    public ExperimentWorker(Sandbox sandbox, IOptions<ExperimentConfig>  config, ExperimentData experimentData,
        PlayerResolver playerResolver)
    {
        _config = config;
        _sandbox = sandbox;
        _experimentData = experimentData;
        _playerResolver = playerResolver;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        if (_config.Value.RunRandomExperiments)
        {
            RunRandomExperiments();
        }

        if (_config.Value.RunWebExperiments)
        {
            await RunWebExperiments();
        }

        if (_config.Value.GenerateDbExperiments)
        {
            GenerateDbExperiments();
        }

        if (_config.Value.RunDbExperiments)
        {
            RunDbExperiments();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
    
    private async void StartApps()
    {
        WebApplication elonApp = WebAppFactory.CreateWebApp(_config.Value.WebConfig.ElonUrl,
            _playerResolver.GetPlayer(PlayerResolver.PlayerType.Elon));
        WebApplication markApp = WebAppFactory.CreateWebApp(_config.Value.WebConfig.MarkUrl,
            _playerResolver.GetPlayer(PlayerResolver.PlayerType.Mark));

        await Task.WhenAll(elonApp.RunAsync(), markApp.RunAsync());
    }
    
    private void RunRandomExperiments()
    {
        var successCount = 0;
        for (var i = 0; i < _config.Value.RandomExperimentsCount; i++)
        {
            if (_sandbox.RunRandomExperiment())
                successCount++;
        }
        Console.WriteLine($"{successCount} / {_config.Value.WebExperimentsCount} = " +
                          $"{(double)successCount / _config.Value.WebExperimentsCount}");
    }

    private async Task RunWebExperiments()
    {
        StartApps();

        var successCount = 0;
        for (var i = 0; i < _config.Value.WebExperimentsCount; i++)
        {
            if (await _sandbox.RunExperimentUsingHttp(_config.Value.WebConfig.ElonUrl, _config.Value.WebConfig.MarkUrl))
                successCount++;
        }
        Console.WriteLine($"{successCount} / {_config.Value.WebExperimentsCount} = " +
                          $"{(double)successCount / _config.Value.WebExperimentsCount}");
    }

    private void GenerateDbExperiments()
    {
        var elonStrategyName = _sandbox.GetElonStrategyName();
        var markStrategyName = _sandbox.GetMarkStrategyName();
        _experimentData.SaveRandomExperiment(elonStrategyName, markStrategyName,
            _config.Value.DbExperimentsCount, _config.Value.DeckSize);
    }

    private void RunDbExperiments()
    {
        var experiments = _experimentData.GetAllConditions();
        var count = experiments.Count(condition => _sandbox.RunExperiment(condition.CardsOrder));
        Console.WriteLine($"DB: {count} /  {experiments.Count}");
    }
}