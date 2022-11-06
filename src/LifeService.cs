using ConwaysGameOfLife.Domain.Cells;

namespace ConwaysGameOfLife.Domain;
public class LifeService
{
    private readonly NeighbourService neighbourService;
    private const int MIN_ALIVE_NEIGHBOURS = 2;
    private const int MAX_ALIVE_NEIGHBOURS = 3;

    public LifeService(NeighbourService neighbourService)
    {
        this.neighbourService = neighbourService;
    }

    public Board GetNextGeneration(Board board)
    {
        var cells = new List<Cell>();
        for (int i = 0; i < board.Cells.Count; i++)
        {
            cells.Add(FigureCell(i, board));
        }
        return new Board(board.Bounds.Width, cells);
    }

    private Cell FigureCell(int index, Board board)
    {
        var neighboursIndexes = neighbourService
            .GetNeighboursIndexes(board.Bounds, index);
        var aliveNeighboursCount = board.Cells
            .Where((x, i) => neighboursIndexes.Contains(i) && x.IsAlive)
            .Count();
        if(IsUnderPopulated(aliveNeighboursCount) || IsOverCrowded(aliveNeighboursCount))
        {
            return new Cell(false);
        }
        return new Cell(true);
    }

    private bool IsOverCrowded(int count) =>
        count > MAX_ALIVE_NEIGHBOURS;

    private bool IsUnderPopulated(int count) => 
        count < MIN_ALIVE_NEIGHBOURS;
}
