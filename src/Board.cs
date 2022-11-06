using ConwaysGameOfLife.Domain.Cells;
using ConwaysGameOfLife.Test;

namespace ConwaysGameOfLife.Domain
{
    public class Board
    {
        
        public List<Cell> Cells { get; }
        public int Size { get; }

        public Board(int size, List<Cell> cells)
        {
            if (cells.Count != GetExpectedCellCount(size))
            {
                throw new CellAmountException($"Expected cells {GetExpectedCellCount(size)} and got {cells.Count}");
            }
            Size = size;
            Cells = cells;
        }

        public List<Cell> GetNeighours(int index)
        {
            List<Cell> neighours = new List<Cell>();
            return neighours;
        }

        private static int GetExpectedCellCount(int size)=>
            (int) Math.Pow(size, 2);
    }
}
