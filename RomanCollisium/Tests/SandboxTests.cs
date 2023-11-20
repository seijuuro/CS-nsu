using Core.Interfaces;
using Core.Models;
using Core.Players;
using Core.Services;
using Core.Strategies;
using Moq;

namespace Tests;

public class SandboxTests
{
    [Fact]
    public void RunExperiment_ShuffleIsCalledOnce()
    {
        //arrange
        var deck = new Deck(36);
        var shufflerMock = ShufflerMockSetup(deck);
        var sandbox = new Sandbox(deck, shufflerMock.Object, new ElonPlayer(new PickFirstRedStrategy()),
            new MarkPlayer(new PickFirstRedStrategy()));

        //act
        sandbox.RunRandomExperiment();

        //assert
        shufflerMock.Verify(shuffler => shuffler.Shuffle(It.IsAny<Deck>()), Times.Once);
        
    }

    [Fact]
    public void RunExperiment_KnownOrder_ReturnsExpectedResult()
    {
        //arrange
        var knownDeck = new Deck(36);
        var shufflerMock = ShufflerMockSetup(knownDeck);
        var sandbox = new Sandbox(knownDeck, shufflerMock.Object, new ElonPlayer(new PickFirstRedStrategy()),
            new MarkPlayer(new PickFirstRedStrategy()));

        //act
        var result = sandbox.RunRandomExperiment();
        
        //assert
        result.Should().BeTrue();
    }

    private Mock<IDeckShuffler> ShufflerMockSetup(Deck deck)
    {
        var shufflerMock = new Mock<IDeckShuffler>();
        shufflerMock.Setup(shuffler => shuffler
            .Shuffle(It.IsAny<Deck>()))
            .Returns(deck);

        return shufflerMock;
    }
}