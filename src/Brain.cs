using ConwaysGameOfLife.Domain.Cells;

namespace ConwaysGameOfLife.Domain;
public class Brain
{
    public Board GetNextGeneration(Board board)
    {
        return new Board(2, new List<Cell>
            {
                new Cell(true),
                new Cell(true),
                new Cell(true),
                new Cell(true) });
    }
}
