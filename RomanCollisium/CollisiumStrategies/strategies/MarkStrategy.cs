using CollisiumCore.Interfaces;
using CollisiumCore.Models.Cards;
using CollisiumCore.strategyDefinitions;

namespace CollisiumStrategies.strategies;

public class MarkStrategy : ICardPickStrategy
{ 
    public int Pick(Card[] cards)
    {
        return StrategyBundle.PickFirstRed(cards);
    }
}