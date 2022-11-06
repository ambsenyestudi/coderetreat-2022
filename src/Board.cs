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

        private List<int> GetNeighboursIndexes(int index) =>
             GetNeighbours(index).OrderBy(x => x).ToList();

        private List<int> GetNeighbours(int index)
        {
            var (x, y) = NeighbourService.To2DCoordinates(Bounds, index);
            if (index == Bounds.GetTopLeft())
            {
                return new List<int> { NeighbourService.ToRight(Bounds,x, y), NeighbourService.ToRightBottom(Bounds,x, y), ToBottom(x, y) };
            }
            if (index == Bounds.GetTopRight())
            {
                return new List<int> { NeighbourService.ToLeft(Bounds,x, y), ToLeftBottom(x, y), ToBottom(x, y) };
            }
            if (index == Bounds.GetBottomLeft())
            {
                return new List<int> { NeighbourService.ToTop(Bounds, x, y), NeighbourService.ToTopRight(Bounds,x, y), NeighbourService.ToRight(Bounds,x, y) };
            }
            if (index == Bounds.GetBottomRight())
            {
                return new List<int> { NeighbourService.ToTopLeft(Bounds,x, y), NeighbourService.ToTop(Bounds, x, y), NeighbourService.ToLeft(Bounds,x, y) };
            }
            return new List<int> { NeighbourService.ToLeft(Bounds,x, y), NeighbourService.ToTopLeft(Bounds,x, y), 
                NeighbourService.ToTop(Bounds, x, y), NeighbourService.ToTopRight(Bounds,x, y), NeighbourService.ToRight(Bounds,x, y), 
                NeighbourService.ToRightBottom(Bounds,x, y), ToBottom(x, y), ToLeftBottom(x, y)
            };
        }

        
        private int ToLeftBottom(int x, int y) =>
            (y + 1) * Bounds.Width + (x - 1);

        private int ToBottom(int x, int y) =>
            (y + 1) * Bounds.Width + x;
        
        private static int GetExpectedCellCount(int size)=>
            (int) Math.Pow(size, 2);
    }
}
