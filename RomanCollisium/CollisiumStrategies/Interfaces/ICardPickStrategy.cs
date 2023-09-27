using CollisiumStrategies.Cards;

namespace CollisiumStrategies;

public interface ICardPickStrategy
{
    public int Pick(Card[] cards);
}