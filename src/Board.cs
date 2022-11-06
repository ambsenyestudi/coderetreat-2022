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
            { ToLeft(x, y), ToLeftTop(x, y), ToTop(x, y),
                ToTopRight(x, y), ToRight(x, y), ToRightBottom(x, y),
                ToBottom(x, y), ToLeftBottom(x, y)
            }.Where(x => x >= 0)
            .OrderBy(x => x)
            .ToList();
            return indexes;
        }

        private int ToLeftBottom(int x, int y) =>
            (y + 1) * Size + (x - 1);

        private int ToBottom(int x, int y) =>
            (y + 1) * Size + x;

        private int ToRightBottom(int x, int y) => 
            (y + 1) * Size + (x + 1);

        private int ToRight(int x, int y) =>
            y * Size + (x + 1);

        private int ToTopRight(int x, int y) =>
            (y - 1) * Size + (x + 1);

        private int ToLeft(int x, int y) =>
            y * Size + (x - 1);
        private int ToLeftTop(int x, int y) =>
            (y - 1) * Size + (x - 1);
        private int ToTop(int x, int y) =>
            (y - 1) * Size + x;

        private (int, int) To2DCoordinates(int index) =>
            (index % Size, index / Size);

        private static int GetExpectedCellCount(int size)=>
            (int) Math.Pow(size, 2);
    }
}
