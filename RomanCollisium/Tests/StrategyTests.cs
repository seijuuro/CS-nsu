using CollisiumCore.Models.Cards;
using CollisiumStrategies.strategies;

namespace Tests;

public class StrategyTests
{
    private readonly MarkStrategy _strategy = new ();
    private Card[] _cards = new Card[18];

    [Fact]
    public void Pick_FirstCardRed_ReturnsZero()
    {
        //arrange
        _cards = GenerateCardsArray(0);

        //act
        var result = _strategy.Pick(_cards);

        //assert
        result.Should().Be(0);
    }

    [Fact]
    public void Pick_LastCardRed_ReturnsSeventeen()
    {
        //arrange
        _cards = GenerateCardsArray(17);

        //act
        var result = _strategy.Pick(_cards);

        //assert
        result.Should().Be(17);
    }

    [Fact]
    public void Pick_MiddleCardRed_ReturnsMiddleIndex()
    {
        //arrange
        _cards = GenerateCardsArray(8);

        //act
        var result = _strategy.Pick(_cards);

        //assert
        result.Should().Be(8);
    }

    [Fact]
    public void Pick_NoRedCards_ReturnsZero()
    {
        //arrange
        _cards = GenerateCardsArray(-1);

        //act
        var result = _strategy.Pick(_cards);

        //assert
        result.Should().Be(0);
    }
    
    private Card[] GenerateCardsArray(int redCardPosition)
    {
        for (var i = 0; i < 18; i++)
        {
            if (i == redCardPosition)
            {
                _cards[i] = new Card(CardColor.Red);
            }
            else
            {
                _cards[i] = new Card(CardColor.Black);
            }
        }
        return _cards;
    }
}