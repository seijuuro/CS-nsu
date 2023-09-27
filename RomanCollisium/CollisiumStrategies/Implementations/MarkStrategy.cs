using CollisiumStrategies.Cards;

namespace CollisiumStrategies;

public class MarkStrategy : ICardPickStrategy
{
    public int Pick(Card[] cards)
    {
        return 1;
    }
}