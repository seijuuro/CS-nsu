using Core.Interfaces;
using Core.Models;
using Core.Models.Cards;

namespace Core.Utilities;

public class DeckShuffler : IDeckShuffler
{
    private readonly Random _random = new (Guid.NewGuid().GetHashCode());
    
    public Deck Shuffle(Deck deck)
    {
        var cards = deck.GetCards();
        for (var i = cards.Count - 1; i > 0; i--)
        {
            var k = _random.Next(i + 1);
            (cards[i], cards[k]) = (cards[k], cards[i]);
        }

        return deck;
    }
}