namespace CollisiumApp;

public class CollisiumSandbox
{
    private Deck _deck;
    private IDeckShufller _shufller;
    private ElonPlayer _elon;
    private MarkPlayer _mark;
    
    public CollisiumSandbox(Deck deck, IDeckShufller deckShufller, ElonPlayer elon, MarkPlayer mark)
    {
        _deck = deck;
        _shufller = deckShufller;
        _elon = elon;
        _mark = mark;
    }

    public bool RunExperiment()
    {
        _deck = _shufller.Shuflle(_deck);
        
        _elon.ReceiveCards(_deck.GetFirstHalf());
        _mark.ReceiveCards(_deck.GetSecondHalf());
        
        //_elon.ShowCards();
        //Console.WriteLine();
        //_mark.ShowCards();
        
        int elonNumber = _elon.PickCard();
        int markNumber = _mark.PickCard();

        return _elon.GetCardColor(markNumber) == _mark.GetCardColor(elonNumber); 
    }

    public void ShowOpponents()
    {
        //_deck.ShowDeck();
        _elon.ShowCards();
        Console.Write("     VS      ");
        _mark.ShowCards();
        Console.WriteLine("");
    }
}