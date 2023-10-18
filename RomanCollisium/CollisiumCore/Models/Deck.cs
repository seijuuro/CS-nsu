using System.Text;
using CollisiumCore.Models.Cards;

namespace CollisiumCore.Models;

public class Deck
{
    private readonly List<Card> _cards;
    private static readonly int cardsCount = 36;
    
    private static readonly Card redCard = new Card(CardColor.Red);
    private static readonly Card blackCard = new Card(CardColor.Black);
    
    public Deck()
    {
        _cards = new List<Card>(cardsCount);
        for (var i = 0; i < cardsCount / 2; i++)
        {
            _cards.Add(redCard);
            _cards.Add(blackCard);
        }
    }
    
    public List<Card> GetCards()
    {
        return _cards;
    }
    
    public List<Card> GetFirstHalf()
    {
        return _cards.Take(_cards.Count / 2).ToList();
    }

    public List<Card> GetSecondHalf()
    {
        return _cards.Skip(_cards.Count / 2).Take(_cards.Count / 2).ToList();
    }

    
    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        foreach (var card in _cards)
        {
            str.Append(card.ToString());
        }

        return str.ToString();
    }
    
    public void ShowDeck()
    {
        Console.WriteLine(this.ToString());
    }
}



