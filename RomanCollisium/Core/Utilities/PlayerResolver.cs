using Core.Models;
using Core.Players;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities;

public class PlayerResolver
{
    private readonly IServiceProvider _serviceProvider;

    public PlayerResolver(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Player GetPlayer(PlayerType playerType)
    {
        return playerType switch
        {
            PlayerType.Elon => _serviceProvider.GetRequiredService<ElonPlayer>(),
            PlayerType.Mark => _serviceProvider.GetRequiredService<MarkPlayer>(),
            _ => throw new ArgumentException("Invalid player type")
        };
    }
    
    public enum PlayerType  
    {
        Mark,
        Elon
    }
}