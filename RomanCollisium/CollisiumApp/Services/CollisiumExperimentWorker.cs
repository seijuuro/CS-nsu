namespace CollisiumApp;

public class CollisiumExperimentWorker : IHostedService
{
    private readonly CollisiumSandbox _sandbox;
    private readonly int _experimentsCount = 1000000;

    public CollisiumExperimentWorker(CollisiumSandbox sandbox)
    {
        _sandbox = sandbox;
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        int successCount = 0;
        for (int i = 0; i < _experimentsCount; i++)
        {
            if (_sandbox.RunExperiment())
                successCount++;
        }
        Console.WriteLine($"{successCount} / {_experimentsCount} = {(double)successCount / _experimentsCount}");
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}