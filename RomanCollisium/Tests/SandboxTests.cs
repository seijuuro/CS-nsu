using CollisiumApp.Players;
using CollisiumApp.Services;
using CollisiumCore.Interfaces;
using CollisiumCore.Models;
using CollisiumStrategies.strategies;
using Moq;

namespace Tests;

public class SandboxTests
{
    [Fact]
    public void RunExperiment_ShuffleIsCalledOnce()
    {
        //arrange
        var mockShuffler = new Mock<IDeckShuffler>();
        mockShuffler.Setup(shuffler => shuffler.Shuffle(It.IsAny<Deck>())).Returns(new Deck());
        var sandbox = new Sandbox(new Deck(), mockShuffler.Object, new ElonPlayer(new ElonStrategy()), new MarkPlayer(new MarkStrategy()));

        //act
        sandbox.RunRandomExperiment();

        //assert
        mockShuffler.Verify(shuffler => shuffler.Shuffle(It.IsAny<Deck>()), Times.Once);
        
    }

    [Fact]
    public void RunExperiment_KnownOrder_ReturnsExpectedResult()
    {
        //arrange
        var knownDeck = new Deck();
        var mockShuffler = new Mock<IDeckShuffler>();
        mockShuffler.Setup(shuffler => shuffler.Shuffle(It.IsAny<Deck>())).Returns(knownDeck);
        var sandbox = new Sandbox(knownDeck, mockShuffler.Object, new ElonPlayer(new ElonStrategy()), new MarkPlayer(new MarkStrategy()));

        //act
        var result = sandbox.RunRandomExperiment();
        
        //assert
        Assert.True(result);
    }
}