using CollisiumCore.Models;

namespace CollisiumCore.Interfaces;

public interface IDeckShuffler
{
    public Deck Shuffle(Deck deck);
}