namespace ConwaysGameOfLife.Domain.Cells
{
    public class NeighbourService
    {
        public List<int> GetNeighboursIndexes(Bounds bounds, int index) =>
            GetIndexes(bounds, index).OrderBy(x => x)
                .ToList();
        private List<int> GetIndexes(Bounds bounds, int index)
        {
            var (x, y) = To2DCoordinates(bounds, index);
            if (index == bounds.GetTopLeft())
            {
                return new List<int> { ToRight(bounds, x, y), ToBottomRight(bounds, x, y), ToBottom(bounds, x, y) };
            }
            if (index == bounds.GetTopRight())
            {
                return new List<int> { ToLeft(bounds, x, y), ToLeftBottom(bounds, x, y), ToBottom(bounds, x, y) };
            }
            if (index == bounds.GetBottomLeft())
            {
                return new List<int> { ToTop(bounds, x, y), ToTopRight(bounds, x, y), ToRight(bounds, x, y) };
            }
            if (index == bounds.GetBottomRight())
            {
                return new List<int> { ToTopLeft(bounds, x, y), ToTop(bounds, x, y), ToLeft(bounds, x, y) };
            }
            return new List<int> { ToLeft(bounds,x, y), ToTopLeft(bounds,x, y),
                ToTop(bounds, x, y), ToTopRight(bounds,x, y), ToRight(bounds,x, y),
                ToBottomRight(bounds,x, y), ToBottom(bounds,x, y), ToLeftBottom(bounds,x, y)
            };
        }

        public int ToLeftBottom(Bounds bounds, int x, int y) =>
            (y + 1) * bounds.Width + (x - 1);
        public int ToBottom(Bounds bounds, int x, int y) =>
            (y + 1) * bounds.Width + x;
        public int ToBottomRight(Bounds bounds, int x, int y) =>
            (y + 1) * bounds.Width + (x + 1);
        public int ToRight(Bounds bounds, int x, int y) =>
            y * bounds.Width + (x + 1);
        public int ToTopRight(Bounds bounds, int x, int y) =>
            (y - 1) * bounds.Width + (x + 1);
        public int ToLeft(Bounds bounds, int x, int y) =>
           y * bounds.Width + (x - 1);
        public int ToTopLeft(Bounds bounds, int x, int y) =>
            (y - 1) * bounds.Width + (x - 1);
        public int ToTop(Bounds bounds, int x, int y) =>
            (y - 1) * bounds.Width + x;
        public (int, int) To2DCoordinates(Bounds bounds, int index) =>
            (index % bounds.Width, index / bounds.Width);
    }
}
