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
            List<int> indexes = GetNeighboursIndexes(index);
            List<Cell> neighours = Cells
                .Where(x => indexes.Contains(x.Id))
                .ToList();
            return neighours;
        }

        private List<int> GetNeighboursIndexes(int index)
        {
            if (Bounds.IsCorner(index))
            {
                return GetCornerNeighbours(index);
            }

            var (x, y) = To2DCoordinates(index);

            var indexes = new List<int>
            { ToLeft(x, y), ToLeftTop(x, y), ToTop(x, y),
                ToRightTop(x, y), ToRight(x, y), ToRightBottom(x, y),
                ToBottom(x, y), ToLeftBottom(x, y)
            }.Where(x => x >= 0)
            .OrderBy(x => x)
            .ToList();
            return indexes;
        }

        private List<int> GetCornerNeighbours(int index)
        {
            var (x, y) = To2DCoordinates(index);
            if (index == 0)
            {
                return new List<int> { ToRight(x, y), ToRightBottom(x, y), ToBottom(x, y) };
            }
            if (index == Bounds.Width-1)
            {
                return new List<int> { ToLeft(x, y), ToLeftBottom(x, y), ToBottom(x, y) };
            }
            if (index == Bounds.Width * Bounds.Height - Bounds.Width)
            {
                return new List<int> { ToTop(x, y), ToRightTop(x, y), ToRight(x, y) };
            }
            return new List<int> { ToLeftTop(x, y), ToTop(x, y), ToLeft(x, y) };
        }

        
        private int ToLeftBottom(int x, int y) =>
            (y + 1) * Bounds.Width + (x - 1);

        private int ToBottom(int x, int y) =>
            (y + 1) * Bounds.Width + x;

        private int ToRightBottom(int x, int y) => 
            (y + 1) * Bounds.Width + (x + 1);

        private int ToRight(int x, int y) =>
            y * Bounds.Width + (x + 1);

        private int ToRightTop(int x, int y) =>
            (y - 1) * Bounds.Width + (x + 1);

        private int ToLeft(int x, int y) =>
            y * Bounds.Width + (x - 1);
        private int ToLeftTop(int x, int y) =>
            (y - 1) * Bounds.Width + (x - 1);
        private int ToTop(int x, int y) =>
            (y - 1) * Bounds.Width + x;

        private (int, int) To2DCoordinates(int index) =>
            (index % Bounds.Width, index / Bounds.Width);

        private static int GetExpectedCellCount(int size)=>
            (int) Math.Pow(size, 2);
    }
}
