using CollisiumDataAccess.Entities;
using CollisiumDataAccess.Repositories;
using Core.Models;
using Core.Utilities;

namespace CollisiumDataAccess.Services;

public class ExperimentData
{
    private readonly ExperimentRepository _experimentRepository;

    public ExperimentData(ExperimentRepository repository)
    {
        _experimentRepository = repository;
    }

    public void SaveRandomExperiment(string firstStrategy, string secondStrategy, int conditionsCount, int cardsCount)
    {
        var deck = new Deck(cardsCount);
        var deckShuffler = new DeckShuffler();
        
        var experiment = new Experiment
        {
            Date = DateTime.Now,
            FirstStrategy = firstStrategy,
            SecondStrategy = secondStrategy,
            Conditions = new List<ExperimentCondition>()
        };

        for (var i = 0; i < conditionsCount; i++)
        {
            deck = deckShuffler.Shuffle(deck);

            var condition = new ExperimentCondition()
            {
                CardsOrder = deck.CardsToString()
            };

            experiment.Conditions.Add(condition);
        }
            
        _experimentRepository.Create(experiment);
    }
    
    public List<ExperimentCondition> GetAllConditions()
    {
        return _experimentRepository.Read<ExperimentCondition>();
    }

    public List<Experiment> GetAllExperiments()
    {
        return _experimentRepository.Read<Experiment>();
    }
}