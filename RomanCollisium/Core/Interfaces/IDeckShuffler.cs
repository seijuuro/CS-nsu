using Core.Models;

namespace Core.Interfaces;

public interface IDeckShuffler
{
    Deck Shuffle(Deck deck);
}