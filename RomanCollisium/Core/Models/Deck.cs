using System.Text;
using Core.Models.Cards;

namespace Core.Models;

public class Deck
{
    private readonly List<Card> _cards;
    private readonly int _cardsCount;
    
    private static readonly Card RedCard = new Card(CardColor.Red);
    private static readonly Card BlackCard = new Card(CardColor.Black);
    
    public Deck(int cardsCount)
    {
        if (cardsCount % 2 != 0)
            throw new ArgumentException("Cards Count must be even number");

        _cardsCount = cardsCount;
        
        _cards = new List<Card>(cardsCount);
        for (var i = 0; i < cardsCount / 2; i++)
        {
            _cards.Add(RedCard);
            _cards.Add(BlackCard);
        }
    }
    
    public List<Card> GetCards()
    {
        return _cards;
    }

    public void SetCards(string cardsOrder)
    {
        if (cardsOrder.Length != _cardsCount) 
            throw new ArgumentException("Invalid string length.");

        _cards.Clear();

        _cards.AddRange(cardsOrder.Select(c => c switch
        {
            'B' => BlackCard,
            'R' => RedCard,
            _ => throw new ArgumentException($"Invalid character '{c}' in string.")
        }));
    }

    public String CardsToString()
    {
        StringBuilder str = new StringBuilder();
        foreach (var card in _cards)
        {
            str.Append(card.ToString());
        }

        return str.ToString();
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
        return $"CardsCount: {_cardsCount}; Cards: {CardsToString()}; ";
    }
}



