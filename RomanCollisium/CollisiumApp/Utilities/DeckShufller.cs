using CollisiumStrategies.Cards;

namespace CollisiumApp;

public class DeckShufller : IDeckShufller
{
    private static Random _random = new Random(Guid.NewGuid().GetHashCode());
     
    
    public Deck Shuflle(Deck deck)
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