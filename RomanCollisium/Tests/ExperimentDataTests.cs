using CollisiumDataAccess.DbContexts;
using CollisiumDataAccess.Entities;
using CollisiumDataAccess.Repositories;
using CollisiumDataAccess.Services;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace Tests;

public class ExperimentDataTests
{
    private ExperimentData _dataService;
    
    private const int ConditionsCount = 10;
    private const int CardsCount = 36;
    private const string FirstStrategyName = "First";
    private const string SecondStrategyName = "Second";

    public ExperimentDataTests(ITestOutputHelper testOutputHelper)
    {
        var options = new DbContextOptionsBuilder<ExperimentDbContext>()
            .UseSqlite("DataSource=:memory:")
            .Options;

        var context = new ExperimentDbContext(options);
        context.Database.OpenConnection();
        context.Database.EnsureCreated();
        
        ExperimentRepository<ExperimentCondition> conditionRepository = new(context);
        ExperimentRepository<Experiment> experimentRepository = new(context);
        _dataService = new ExperimentData(conditionRepository, experimentRepository);
    }
    

    [Fact]
    public void CreateAnExperiment_ExperimentSavedOnDb() 
    {
        //act 
        _dataService.SaveRandomExperiment(FirstStrategyName, SecondStrategyName, ConditionsCount, CardsCount);
        var experimentsCount = _dataService.GetAllExperiments().Count;

        //assert
        experimentsCount.Should().Be(1);
    }

    [Fact]
    public void CreateAnExperiment_ConditionsSavedOnDb() 
    {
        //act 
        _dataService.SaveRandomExperiment(FirstStrategyName, SecondStrategyName, ConditionsCount, CardsCount);
        var conditionsCount = _dataService.GetAllConditions().Count;

        //assert
        conditionsCount.Should().Be(ConditionsCount);
    }
    
    [Fact]
    public void CreateAnExperiment_ExperimentFieldsNotEmpty()
    {
        //act
        _dataService.SaveRandomExperiment(FirstStrategyName, SecondStrategyName, ConditionsCount, CardsCount);
        var experiment = _dataService.GetAllExperiments().FirstOrDefault();

        //assert
        experiment.Should().NotBeNull();
        experiment.FirstStrategy.Should().NotBeNullOrEmpty();
        experiment.SecondStrategy.Should().NotBeNullOrEmpty();
        experiment.Date.Should().NotBe(DateTime.MinValue);
    }
    
    [Fact]
    public void CreateAnExperiment_ConditionFieldsNotEmpty()
    {
        //act
        _dataService.SaveRandomExperiment(FirstStrategyName, SecondStrategyName, ConditionsCount, CardsCount);
        var condition = _dataService.GetAllConditions().FirstOrDefault();

        //assert
        condition.Should().NotBeNull();
        condition.ExperimentId.Should().NotBe(default);
        condition.CardsOrder.Should().NotBeNullOrEmpty();
    }
}