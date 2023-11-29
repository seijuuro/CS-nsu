using Core.Interfaces;
using Core.Models;
using Core.Players;

namespace Core.Services;

public class Sandbox
{
    private Deck _deck;
    private readonly IDeckShuffler _shuffler;
    private readonly ElonPlayer _elon;
    private readonly MarkPlayer _mark;
    
    public Sandbox(Deck deck, IDeckShuffler deckShuffler, ElonPlayer elon, MarkPlayer mark)
    {
        _deck = deck;
        _shuffler = deckShuffler;
        _elon = elon;
        _mark = mark;
    }

    public bool RunRandomExperiment()
    {
        _deck = _shuffler.Shuffle(_deck);
        
        return CardsDraft();
    }
    
    public bool RunExperiment(string cardsOrder)
    {
        _deck.SetCards(cardsOrder);
        
        return CardsDraft();
    }
    
    public string GetElonStrategyName()
    {
        return _elon.GetStrategyName();
    }

    public string GetMarkStrategyName()
    {
        return _mark.GetStrategyName();
    }

    private bool CardsDraft()
    {
        _elon.ReceiveCards(_deck.GetFirstHalf());
        _mark.ReceiveCards(_deck.GetSecondHalf());
        
        var elonNumber = _elon.PickCard();
        var markNumber = _mark.PickCard();

        return CheckCardsColor(elonNumber, markNumber);
    }
    
    private bool CheckCardsColor(int elonNumber, int markNumber)
    {
        var cards = _deck.GetCards();
        
        return cards.ElementAt(elonNumber + cards.Count / 2).Color == cards.ElementAt(markNumber).Color;
    }
}