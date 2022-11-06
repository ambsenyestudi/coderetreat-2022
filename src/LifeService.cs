using ConwaysGameOfLife.Domain.Cells;

namespace ConwaysGameOfLife.Domain;
public class LifeService
{
    private readonly NeighbourService neighbourService;

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

        return new Cell(index, aliveNeighboursCount == 2 || aliveNeighboursCount == 3);
    }
}
