using System.Text;
using CollisiumCore.Interfaces;
using CollisiumCore.Models.Cards;

namespace CollisiumApp.Models;

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