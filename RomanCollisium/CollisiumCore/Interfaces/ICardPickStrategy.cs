using CollisiumCore.Models.Cards;

namespace CollisiumCore.Interfaces;

public interface ICardPickStrategy
{
    public int Pick(Card[] cards);
}