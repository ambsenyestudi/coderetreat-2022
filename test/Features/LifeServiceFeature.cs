using ConwaysGameOfLife.Domain;
using ConwaysGameOfLife.Domain.Cells;

namespace ConwaysGameOfLife.Test.Features;

public class LifeServiceFeature
{
    /*
     .*
     **
     
     **
     **
     */
    [Fact]
    public void AliveWhenThreeAliveNeighbours()
    {
        var brain = new LifeService(new NeighbourService());
        var board = new BoardBuilder().WithSize(2)
            .WithCellStates(
            false, true,
            true, true).Build();

        var nextGeneration = brain.GetNextGeneration(board);

        Assert.Collection(nextGeneration.Cells,
            x => Assert.True(x.IsAlive),
            x => Assert.True(x.IsAlive),
            x => Assert.True(x.IsAlive),
            x => Assert.True(x.IsAlive));
    }
}