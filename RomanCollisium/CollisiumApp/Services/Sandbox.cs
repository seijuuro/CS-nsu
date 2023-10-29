using CollisiumApp.Players;
using CollisiumCore.Interfaces;
using CollisiumCore.Models;

namespace CollisiumApp.Services;

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
        
        return CardsDraft(_deck);
    }

    // не уверен, что тут нужна перегрузка
    public bool RunExperiment(string cardsOrder)
    {
        _deck.CardsFromString(cardsOrder);
        
        return CardsDraft(_deck);
    }

    private bool CardsDraft(Deck deck)
    {
        _elon.ReceiveCards(deck.GetFirstHalf());
        _mark.ReceiveCards(deck.GetSecondHalf());
        
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