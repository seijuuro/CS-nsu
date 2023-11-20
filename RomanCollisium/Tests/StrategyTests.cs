using Core.Interfaces;
using Core.Models.Cards;
using Core.Strategies;

namespace Tests;

public class StrategyTests
{
    private const int CardsCount = 18;
    private Card[] _cards = new Card[CardsCount];
    private readonly ICardPickStrategy _strategy = new PickFirstRedStrategy();

    [Theory]
    [InlineData(0, 0)]
    [InlineData(CardsCount / 2 - 1, CardsCount / 2 - 1)]
    [InlineData(CardsCount - 1, CardsCount - 1)]
    [InlineData(-1, 0)]
    public void Pick_RedCardPosition_ReturnExpectedResult(int redCardPosition, int expectedResult)
    {
        //arrange
        _cards = GenerateCardsArray(redCardPosition);

        //act
        var result = _strategy.Pick(_cards);

        //assert
        result.Should().Be(expectedResult);
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