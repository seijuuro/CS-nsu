using Core.Models;

namespace Core.Interfaces;

public interface IDeckShuffler
{
    public Deck Shuffle(Deck deck);
}