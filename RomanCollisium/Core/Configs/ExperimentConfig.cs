namespace Core.Configs;

public class ExperimentConfig
{
    public bool GenerateDbExperiments { get; set; }
    public bool RunRandomExperiments { get; set; }
    public bool RunWebExperiments { get; set; }
    public bool RunDbExperiments { get; set; }
    public int DbExperimentsCount { get; set; }
    public int RandomExperimentsCount { get; set; }
    public int WebExperimentsCount { get; set; }
    public int DeckSize { get; set; }

    public WebConfig WebConfig { get; set; }
}