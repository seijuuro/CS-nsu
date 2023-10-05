using CollisiumApp;
using CollisiumStrategies.Cards;

namespace Tests;

public class DeckTests
{
    private readonly Deck _deck = new();
    
    [Fact]
    public void Init_Correctly()
    {

        var cards = _deck.GetCards();
        var redCount = cards.Count(c => c.Color == CardColor.Red);
        var blackCount = cards.Count(c => c.Color == CardColor.Black);

        Assert.Equal(18, redCount);
        Assert.Equal(18, blackCount);
    }
}