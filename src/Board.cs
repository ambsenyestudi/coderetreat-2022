using ConwaysGameOfLife.Domain.Cells;
using ConwaysGameOfLife.Test;

namespace ConwaysGameOfLife.Domain
{
    public class Board
    {
        
        public List<Cell> Cells { get; }
        public Bounds Bounds { get; }

        public Board(int size, List<Cell> cells)
        {
            if (cells.Count != GetExpectedCellCount(size))
            {
                throw new CellAmountException($"Expected cells {GetExpectedCellCount(size)} and got {cells.Count}");
            }
            Bounds = new Bounds(size);
            Cells = cells;
        }

        public List<Cell> GetNeighours(int index)
        {
            List<int> indexes = NeighbourService.GetNeighboursIndexes(Bounds, index);

            return Cells
                .Where(x => indexes.Contains(x.Id))
                .ToList(); ;
        }
        
        private static int GetExpectedCellCount(int size)=>
            (int) Math.Pow(size, 2);
    }
}
