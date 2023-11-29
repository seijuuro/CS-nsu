namespace CollisiumDataAccess.Entities;

public class ExperimentCondition
{
    public int Id { get; set; }
    public string CardsOrder { get; set; }
    
    public int ExperimentId { get; set; }
    public Experiment Experiment { get; set; }
}