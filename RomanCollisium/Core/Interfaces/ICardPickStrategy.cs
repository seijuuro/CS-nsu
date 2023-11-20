using Core.Models.Cards;

namespace Core.Interfaces;

public interface ICardPickStrategy
{
    int Pick(IEnumerable<Card> cards);
}