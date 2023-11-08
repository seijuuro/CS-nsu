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
        var mockShuffler = new Mock<IDeckShuffler>();
        mockShuffler.Setup(shuffler => shuffler.Shuffle(It.IsAny<Deck>())).Returns(new Deck(36));
        var sandbox = new Sandbox(new Deck(36), mockShuffler.Object, new ElonPlayer(new PickFirstRedStrategy()), new MarkPlayer(new PickFirstRedStrategy()));

        //act
        sandbox.RunRandomExperiment();

        //assert
        mockShuffler.Verify(shuffler => shuffler.Shuffle(It.IsAny<Deck>()), Times.Once);
        
    }

    [Fact]
    public void RunExperiment_KnownOrder_ReturnsExpectedResult()
    {
        //arrange
        var knownDeck = new Deck(36);
        var mockShuffler = new Mock<IDeckShuffler>();
        mockShuffler.Setup(shuffler => shuffler.Shuffle(It.IsAny<Deck>())).Returns(knownDeck);
        var sandbox = new Sandbox(knownDeck, mockShuffler.Object, new ElonPlayer(new PickFirstRedStrategy()), new MarkPlayer(new PickFirstRedStrategy()));

        //act
        var result = sandbox.RunRandomExperiment();
        
        //assert
        result.Should().BeTrue();
    }
}