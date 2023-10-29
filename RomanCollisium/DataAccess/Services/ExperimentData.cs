using CollisiumCore.Interfaces;
using CollisiumCore.Models;
using CollisiumDataAccess.Entities;
using CollisiumDataAccess.Repositories;

namespace CollisiumDataAccess.Services;

public class ExperimentData
{
    private ExperimentRepository _repository;

    public ExperimentData(ExperimentRepository repository)
    {
        _repository = repository;
    }
    
    public void GenerateAndSave(IDeckShuffler deckShuffler, int count)
    {
        var conditions = new List<ExperimentCondition>();
        var deck = new Deck();
        
        for (int i = 0; i < count; i++)
        {
            deck = deckShuffler.Shuffle(deck);

            var condition = new ExperimentCondition()
            {
                CardsOrder = deck.ToString().Replace(" ", "")
            };

            conditions.Add(condition);
        }
        
        _repository.Save(conditions);
    }

    public List<ExperimentCondition> GetAllData()
    {
        return _repository.Read();
    }
}