using Core.Interfaces;
using Core.Models.Cards;

namespace Core.Strategies;

public class PickFirstRedStrategy : IElonStrategy, IMarkStrategy
{
    public int Pick(IEnumerable<Card> cards)
    {
        return cards
            .Select((card, i) => card.Color == CardColor.Red ? i : -1)
            .FirstOrDefault(i => i != -1);
    }
}