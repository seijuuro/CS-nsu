using CollisiumApp.Players;
using CollisiumCore.Interfaces;
using CollisiumCore.Models;

namespace CollisiumApp.Services;

public class CollisiumSandbox
{
    private Deck _deck;
    private readonly IDeckShuffler _shuffler;
    private readonly ElonPlayer _elon;
    private readonly MarkPlayer _mark;
    
    
    
    public CollisiumSandbox(Deck deck, IDeckShuffler deckShuffler, ElonPlayer elon, MarkPlayer mark)
    {
        _deck = deck;
        _shuffler = deckShuffler;
        _elon = elon;
        _mark = mark;
    }

    public bool RunExperiment()
    {
        _deck = _shuffler.Shuffle(_deck);
        
        _elon.ReceiveCards(_deck.GetFirstHalf());
        _mark.ReceiveCards(_deck.GetSecondHalf());
        
        int elonNumber = _elon.PickCard();
        int markNumber = _mark.PickCard();

        return CheckCardsColor(elonNumber, markNumber);
    }

    private bool CheckCardsColor(int elonNumber, int markNumber)
    {
        var cards = _deck.GetCards();
        
        return cards.ElementAt(elonNumber + cards.Count / 2).Color == cards.ElementAt(markNumber).Color;
    }
    
    public void ShowOpponents()
    {
        _elon.ShowCards();
        Console.Write("     VS      ");
        _mark.ShowCards();
        Console.WriteLine("");
    }
}