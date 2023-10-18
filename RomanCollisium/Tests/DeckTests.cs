using CollisiumCore.Models;
using CollisiumCore.Models.Cards;
using FluentAssertions.Execution;

namespace Tests;

public class DeckTests
{
    private readonly Deck _deck = new();
    
    [Fact]
    public void Init_Correctly()
    {
        //arrange
        var cards = _deck.GetCards();
        
        //act
        var redCount = cards.Count(c => c.Color == CardColor.Red);
        var blackCount = cards.Count(c => c.Color == CardColor.Black);

        //assert
        using (new AssertionScope())
        {
            redCount.Should().Be(18);
            blackCount.Should().Be(18);
        }
    }
}