using CollisiumCore.Interfaces;
using CollisiumCore.Models.Cards;
using CollisiumCore.strategyDefinitions;

namespace CollisiumStrategies.strategies;

public class ElonStrategy : ICardPickStrategy
{
    public int Pick(Card[] cards)
    {
        return StrategyBundle.PickFirstRed(cards);
    }
}