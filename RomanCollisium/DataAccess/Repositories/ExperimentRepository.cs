using CollisiumDataAccess.DbContexts;

namespace CollisiumDataAccess.Repositories;

public class ExperimentRepository 
{
    private readonly ExperimentDbContext _context;

    public ExperimentRepository(ExperimentDbContext context)
    {
        _context = context;
    }
    
    public void Create<TEntity>(List<TEntity> entities)  where TEntity : class
    {
        _context.Set<TEntity>().AddRange(entities);
        _context.SaveChanges();
    }
 
    public void Create<TEntity>(TEntity entity) where TEntity : class
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
    }
    
    public List<TEntity> Read<TEntity>() where TEntity : class
    {
        return _context.Set<TEntity>().ToList();
    }
}