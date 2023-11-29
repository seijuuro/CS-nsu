namespace Core.Configs;

public class ExperimentConfig
{
    public bool GenerateExperimentsDb { get; set; }
    public bool RunExperimentsDb { get; set; }
    public int ExperimentsDbCount { get; set; }
    public int ExperimentsToRunCount { get; set; }
    public int DeckSize { get; set; }
}