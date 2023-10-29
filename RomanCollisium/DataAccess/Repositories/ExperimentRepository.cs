using CollisiumDataAccess.DbContexts;
using CollisiumDataAccess.Entities;

namespace CollisiumDataAccess.Repositories;

public class ExperimentRepository
{
    private readonly ExperimentDbContext _context;
    
    public ExperimentRepository(ExperimentDbContext context)
    {
        _context = context;
    }
    
    public void Save(List<ExperimentCondition> conditions)
    {
        _context.ExperimentConditions.AddRange(conditions);
        _context.SaveChanges();
    }
    
    public List<ExperimentCondition> Read()
    {
        return _context.ExperimentConditions.ToList();
    }
}

