using CollisiumStrategies.Cards;

namespace CollisiumStrategies;

public class MarkStrategy : ICardPickStrategy
{
    public int Pick(Card[] cards)
    {  
        for(int i = 0; i < cards.Length; i++)
        {
            if (cards[i].Color == CardColor.Red)
                return i;
        }

        return 0;
    }
}