using Core.Interfaces;
using Core.Models;
using Core.Players;

namespace Core.Services;

public class Sandbox
{
    private Deck _deck;
    private readonly IDeckShuffler _shuffler;
    public readonly ElonPlayer Elon;
    public readonly MarkPlayer Mark;
    
    public Sandbox(Deck deck, IDeckShuffler deckShuffler, ElonPlayer elon, MarkPlayer mark)
    {
        _deck = deck;
        _shuffler = deckShuffler;
        Elon = elon;
        Mark = mark;
    }

    public bool RunRandomExperiment()
    {
        _deck = _shuffler.Shuffle(_deck);
        
        return CardsDraft(_deck);
    }

    // не уверен, что тут нужна перегрузка
    public bool RunExperiment(string cardsOrder)
    {
        _deck.SetCards(cardsOrder);
        
        return CardsDraft(_deck);
    }

    private bool CardsDraft(Deck deck)
    {
        Elon.ReceiveCards(deck.GetFirstHalf());
        Mark.ReceiveCards(deck.GetSecondHalf());
        
        int elonNumber = Elon.PickCard();
        int markNumber = Mark.PickCard();

        return CheckCardsColor(elonNumber, markNumber);
    }
    
    private bool CheckCardsColor(int elonNumber, int markNumber)
    {
        var cards = _deck.GetCards();
        
        return cards.ElementAt(elonNumber + cards.Count / 2).Color == cards.ElementAt(markNumber).Color;
    }
    
    public void ShowOpponents()
    {
        Elon.ShowCards();
        Console.Write("     VS      ");
        Mark.ShowCards();
        Console.WriteLine("");
    }
}