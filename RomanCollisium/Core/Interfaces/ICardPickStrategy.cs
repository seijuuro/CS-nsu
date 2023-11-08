using Core.Models.Cards;

namespace Core.Interfaces;

public interface ICardPickStrategy
{
    public int Pick(Card[] cards);
}