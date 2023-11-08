using Core.Interfaces;
using Core.Models.Cards;

namespace Core.Strategies;

public class PickFirstRedStrategy : IElonStrategy, IMarkStrategy
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