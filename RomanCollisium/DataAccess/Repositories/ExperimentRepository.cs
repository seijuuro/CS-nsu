using CollisiumDataAccess.DbContexts;

namespace CollisiumDataAccess.Repositories;

public class ExperimentRepository <TEntity> where TEntity : class
{
    private readonly ExperimentDbContext _context;

    public ExperimentRepository(ExperimentDbContext context)
    {
        _context = context;
    }
    
    public void Create(List<TEntity> entities)
    {
        _context.Set<TEntity>().AddRange(entities);
        _context.SaveChanges();
    }

    public void Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
    }
    
    public List<TEntity> Read()
    {
        return _context.Set<TEntity>().ToList();
    }
}