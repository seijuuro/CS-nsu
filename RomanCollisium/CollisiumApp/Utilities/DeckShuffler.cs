using CollisiumCore.Interfaces;
using CollisiumCore.Models;
using CollisiumCore.Models.Cards;

namespace CollisiumApp.Utilities;

public class DeckShuffler : IDeckShuffler
{
    private static Random _random = new Random(Guid.NewGuid().GetHashCode());
    
    public Deck Shuffle(Deck deck)
    {
        List<Card> cards = deck.GetCards();
        for (var i = cards.Count - 1; i > 0; i--)
        {
            var k = _random.Next(i + 1);
            (cards[i], cards[k]) = (cards[k], cards[i]);
        }

        return deck;
    }
}