using CollisiumStrategies;
using CollisiumStrategies.Cards;

namespace Tests;

public class StrategyTests
{
    private readonly MarkStrategy _strategy = new ();
    private Card[] _cards = new Card[18];

    [Fact]
    public void Pick_FirstCardRed_ReturnsZero()
    {
        _cards = GenerateCardsArray(0);

        var result = _strategy.Pick(_cards);

        Assert.Equal(0, result);
    }

    [Fact]
    public void Pick_LastCardRed_ReturnsSeventeen()
    {
        _cards = GenerateCardsArray(17);

        var result = _strategy.Pick(_cards);

        Assert.Equal(17, result);
    }

    [Fact]
    public void Pick_MiddleCardRed_ReturnsMiddleIndex()
    {
        _cards = GenerateCardsArray(8);

        var result = _strategy.Pick(_cards);

        Assert.Equal(8, result);
    }

    [Fact]
    public void Pick_NoRedCards_ReturnsZero()
    {
        _cards = GenerateCardsArray(-1);

        var result = _strategy.Pick(_cards);

        Assert.Equal(0, result);
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