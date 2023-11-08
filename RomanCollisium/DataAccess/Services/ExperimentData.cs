using CollisiumDataAccess.Entities;
using CollisiumDataAccess.Repositories;
using Core.Models;
using Core.Utilities;

namespace CollisiumDataAccess.Services;

public class ExperimentData
{
    private readonly ExperimentRepository<ExperimentCondition> _conditionsExperimentRepository;
    private readonly ExperimentRepository<Experiment> _experimentRepository;

    public ExperimentData(ExperimentRepository<ExperimentCondition> conditionsRepository, ExperimentRepository<Experiment> experimentRepository)
    {
        _conditionsExperimentRepository = conditionsRepository;
        _experimentRepository = experimentRepository;
    }

    public void SaveRandomExperiment(string firstStrategy, string secondStrategy, int conditionsCount, int cardsCount)
    {
        var deck = new Deck(cardsCount);
        var deckShuffler = new DeckShuffler();
        
        var experiment = new Experiment()
        {
            Date = DateTime.Now,
            FirstStrategy = firstStrategy,
            SecondStrategy = secondStrategy
        };
        _experimentRepository.Create(experiment);
        
        var conditions = new List<ExperimentCondition>();
        
        for (int i = 0; i < conditionsCount; i++)
        {
            deck = deckShuffler.Shuffle(deck);

            var condition = new ExperimentCondition()
            {
                ExperimentId = experiment.Id,
                CardsOrder = deck.CardsToString()
            };

            conditions.Add(condition);
        }
        
        _conditionsExperimentRepository.Create(conditions);
    }
    
    public List<ExperimentCondition> GetAllConditions()
    {
        return _conditionsExperimentRepository.Read();
    }

    public List<Experiment> GetAllExperiments()
    {
        return _experimentRepository.Read();
    }
}