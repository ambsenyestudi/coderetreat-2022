namespace ConwaysGameOfLife.Domain.Cells
{
    public class NeighbourService
    {
        public static int ToRight(Bounds bounds, int x, int y) =>
            y * bounds.Width + (x + 1);

        public static int ToRightTop(Bounds bounds, int x, int y) =>
            (y - 1) * bounds.Width + (x + 1);
        public static int ToLeft(Bounds bounds, int x, int y) =>
           y * bounds.Width + (x - 1);
        public static int ToLeftTop(Bounds bounds, int x, int y) =>
            (y - 1) * bounds.Width + (x - 1);
        public static int ToTop(Bounds bounds, int x, int y) =>
            (y - 1) * bounds.Width + x;
        public static (int, int) To2DCoordinates(Bounds bounds, int index) =>
            (index % bounds.Width, index / bounds.Width);
    }
}
