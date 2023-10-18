using CollisiumApp.Models;
using CollisiumCore.Interfaces;

namespace CollisiumApp.Players;

public class MarkPlayer : Player
{
    public MarkPlayer(ICardPickStrategy strategy) : base(strategy)
    {
    }

}