using System.ComponentModel.DataAnnotations.Schema;

namespace CollisiumDataAccess.Entities;

public class Experiment
{
    public int Id { get; set; }
    [Column(TypeName = "TEXT")] public DateTime Date { get; set; }
    public string FirstStrategy { get; set; }
    public string SecondStrategy { get; set; }
}