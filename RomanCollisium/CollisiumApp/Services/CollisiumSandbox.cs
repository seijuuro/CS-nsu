namespace CollisiumApp;

public class CollisiumSandbox
{
    private Deck _deck;
    private IDeckShuffler _shuffler;
    private ElonPlayer _elon;
    private MarkPlayer _mark;
    
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

        return _elon.GetCardColor(markNumber) == _mark.GetCardColor(elonNumber); 
    }

    public void ShowOpponents()
    {
        _elon.ShowCards();
        Console.Write("     VS      ");
        _mark.ShowCards();
        Console.WriteLine("");
    }
}