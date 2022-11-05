using ConwaysGameOfLife.Domain.Cells;
using ConwaysGameOfLife.Test;

namespace ConwaysGameOfLife.Domain
{
    public class Board
    {
        
        public List<Cell> Cells { get; set; }
        public Board(int size, List<Cell> cells)
        {
            if(cells.Count != Math.Pow(size , 2)) 
            { 
                throw new CellAmountException($"Expected cells {Math.Pow(size, 2)} and got {cells.Count}");
            }
        }

    }
}
