using System.Text;
using CollisiumStrategies;
using CollisiumStrategies.Cards;

namespace CollisiumApp;

public class Player
{
    private readonly ICardPickStrategy _strategy;
    private List<Card> _cards;

    public Player(ICardPickStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ReceiveCards(List<Card> cards)
    {
        _cards = cards;
    }

    public int PickCard()
    {
        return _strategy.Pick(_cards.ToArray());
    }

    public CardColor GetCardColor(int index)
    {
        return _cards.ElementAt(index).Color;
    }

    public void ShowCards()
    {
        StringBuilder str = new StringBuilder();
        foreach (var card in _cards)
        {
            str.Append(card.ToString());
        }
        
        Console.Write(str);
    }
}