using Core.Models;
using Core.Models.Cards;
using FluentAssertions.Execution;

namespace Tests;

public class DeckTests
{

    [Theory]
    [InlineData(2)]
    [InlineData(36)]
    [InlineData(100)]
    public void Init_Correctly(int cardsCount)
    {
        //arrange
        Deck deck = new (cardsCount);
        var cards = deck.GetCards();
        
        //act
        var redCount = cards.Count(c => c.Color == CardColor.Red);
        var blackCount = cards.Count(c => c.Color == CardColor.Black);

        //assert
        using (new AssertionScope())
        {
            redCount.Should().Be(cardsCount/2);
            blackCount.Should().Be(cardsCount/2);
        }
    }
}