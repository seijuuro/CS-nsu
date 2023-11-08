using Core.Interfaces;
using Core.Models;

namespace Core.Players;

public class ElonPlayer : Player
{
    public ElonPlayer(IElonStrategy strategy) : base(strategy)
    {
    }
}