using CollisiumCore.Models.Cards;

namespace CollisiumCore.strategyDefinitions;

public static class StrategyBundle
{
    public static int PickFirstRed(Card[] cards)
    {
        for(int i = 0; i < cards.Length; i++)
        {
            if (cards[i].Color == CardColor.Red)
                return i;
        }

        return 0;
    }
}