using CollisiumDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollisiumDataAccess.DbContexts;
    
public class ExperimentDbContext : DbContext
{ 
    public DbSet<Experiment> Experiments { get; set; } 
    public DbSet<ExperimentCondition> ExperimentConditions { get; set; }
    
    public ExperimentDbContext(DbContextOptions<ExperimentDbContext> options) : base(options)
    {
    }
}
