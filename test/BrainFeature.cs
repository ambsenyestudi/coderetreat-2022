using ConwaysGameOfLife.Domain;

namespace ConwaysGameOfLife.Test;

public class BrainFeature
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
        var brain = new Brain();
        var nextGeneration = brain.GetNextGeneration(new Board(2, new List<Cell> { new Cell(false), new Cell(true), new Cell(true), new Cell(true) }));
        Assert.Collection(nextGeneration.Cells, x=> Assert.True(x.IsAlive));
    }
}