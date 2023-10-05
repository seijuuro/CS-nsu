using CollisiumApp;
using CollisiumStrategies;
using Moq;

namespace Tests;

public class SandboxTests
{
    [Fact]
    public void RunExperiment_ShuffleIsCalledOnce()
    {
        var mockShuffler = new Mock<IDeckShuffler>();
        mockShuffler.Setup(shuffler => shuffler.Shuffle(It.IsAny<Deck>())).Returns(new Deck());
        var sandbox = new CollisiumSandbox(new Deck(), mockShuffler.Object, new ElonPlayer(new ElonStrategy()), new MarkPlayer(new MarkStrategy()));

        sandbox.RunExperiment();

        mockShuffler.Verify(shuffler => shuffler.Shuffle(It.IsAny<Deck>()), Times.Once);
        
    }

    [Fact]
    public void RunExperiment_KnownOrder_ReturnsExpectedResult()
    {
        var knownDeck = new Deck();
        
        var mockShuffler = new Mock<IDeckShuffler>();
        mockShuffler.Setup(shuffler => shuffler.Shuffle(It.IsAny<Deck>())).Returns(knownDeck);
        var sandbox = new CollisiumSandbox(knownDeck, mockShuffler.Object, new ElonPlayer(new ElonStrategy()), new MarkPlayer(new MarkStrategy()));

        var result = sandbox.RunExperiment();
        
        Assert.True(result);
    }
}