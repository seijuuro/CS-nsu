using Core.Models;
using Core.Models.Cards;
using Microsoft.AspNetCore.Mvc;

namespace PlayerWebLib;

[Route("player")]
public class PlayerController : ControllerBase
{
    private readonly Player _player;

    public PlayerController(Player player)
    {
        _player = player;
    }

    [HttpPost("receive-cards")]
    public IActionResult ReceiveCards([FromBody] List<Card> cards)
    {
        _player.ReceiveCards(cards);
        return Ok();
    }

    [HttpGet("pick-card")]
    public IActionResult PickCard()
    {
        var cardIndex = _player.PickCard();
        return Ok(cardIndex);
    }
}