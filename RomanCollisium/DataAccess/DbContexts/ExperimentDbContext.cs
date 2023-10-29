using CollisiumDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollisiumDataAccess.DbContexts;
    
public class ExperimentDbContext : DbContext
{ 
    public DbSet<ExperimentCondition> ExperimentConditions { get; set; }

    public ExperimentDbContext(DbContextOptions<ExperimentDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExperimentCondition>()
            .HasKey(e => e.Id);
    }
}
