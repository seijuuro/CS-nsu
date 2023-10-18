namespace CollisiumApp.Services;

public class CollisiumExperimentWorker : IHostedService
{
    private const int ExperimentsCount = 1000000;
    private readonly CollisiumSandbox _sandbox;

    public CollisiumExperimentWorker(CollisiumSandbox sandbox)
    {
        _sandbox = sandbox;
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        int successCount = 0;
        for (int i = 0; i < ExperimentsCount; i++)
        {
            if (_sandbox.RunExperiment())
                successCount++;
        }
        Console.WriteLine($"{successCount} / {ExperimentsCount} = {(double)successCount / ExperimentsCount}");
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}