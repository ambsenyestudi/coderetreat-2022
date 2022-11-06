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
            List<int> indexes = GetNeighboursIndexes(index);
            List<Cell> neighours = Cells
                .Where(x => indexes.Contains(x.Id))
                .ToList();
            return neighours;
        }

        private List<int> GetNeighboursIndexes(int index)
        {
            var (x, y) = To2DCoordinates(index);

            var indexes = new List<int>
            {
                y * Size + (x-1), (y-1) * Size + (x-1), (y-1) * Size + x,
                (y - 1) * Size + (x+1), y * Size + (x+1), (y+1) * Size + (x+1),
                (y+1) * Size + x, (y+1) * Size + (x-1)
            }.Where(x => x >= 0)
            .OrderBy(x => x)
            .ToList();
            return indexes;
        }

        private (int, int) To2DCoordinates(int index) =>
            (index % Size, index / Size);

        private static int GetExpectedCellCount(int size)=>
            (int) Math.Pow(size, 2);
    }
}
