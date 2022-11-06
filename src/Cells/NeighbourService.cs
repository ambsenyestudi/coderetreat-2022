namespace ConwaysGameOfLife.Domain.Cells
{
    public class NeighbourService
    {
        public static (int, int) To2DCoordinates(Bounds bounds, int index) =>
            (index % bounds.Width, index / bounds.Width);
    }
}
