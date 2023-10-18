using CollisiumApp.Models;
using CollisiumCore.Interfaces;

namespace CollisiumApp.Players;

public class ElonPlayer : Player
{
    public ElonPlayer(ICardPickStrategy strategy) : base(strategy)
    {
    }
}