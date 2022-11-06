using ConwaysGameOfLife.Domain.Cells;

namespace ConwaysGameOfLife.Domain;
public class Brain
{
    public Board GetNextGeneration(Board board)
    {
        var cells = new List<Cell>();
        for (int i = 0; i < board.Cells.Count; i++)
        {
            cells.Add(FigureCell(board.Cells[i], board.Cells));
        }
        return new Board(board.Bounds.Width, cells);
    }

    private Cell FigureCell(Cell cell, List<Cell> cells)
    {
        return new Cell(cell.Id, true);
    }
}
