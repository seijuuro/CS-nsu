using Core.Interfaces;
using Core.Models;

namespace Core.Players;

public class MarkPlayer : Player
{
    public MarkPlayer(IMarkStrategy strategy) : base(strategy)
    {
    }

}