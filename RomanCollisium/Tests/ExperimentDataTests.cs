using CollisiumApp.Utilities;
using CollisiumDataAccess.DbContexts;
using CollisiumDataAccess.Repositories;
using CollisiumDataAccess.Services;
using Microsoft.EntityFrameworkCore;

namespace Tests;

public class ExperimentDataTests
{
    private ExperimentDbContext _context;

    public ExperimentDataTests()
    {
        var options = new DbContextOptionsBuilder<ExperimentDbContext>()
            .UseSqlite("DataSource=:memory:")
            .Options;

        _context = new ExperimentDbContext(options);
        _context.Database.OpenConnection();
        _context.Database.EnsureCreated();
    }

    [Fact]
    public void GenerateExperiment_ConditionsSavedOnDb() //название так себе
    {
        var repository = new ExperimentRepository(_context);
        var dataService = new ExperimentData(repository);
        
        // заменить шафлер на мок? 
        dataService.GenerateAndSave(new DeckShuffler(), 1);
        var conditions = dataService.GetAllData();
        var result = conditions.Count;

        result.Should().Be(1);
    }

    [Fact]
    public void GetData_ReturnCorrectData() // название, проверка на корректное сохранение(длина 36, в виде строки единиц и нулей)
    {
        
    }
}