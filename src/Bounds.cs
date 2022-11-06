namespace ConwaysGameOfLife.Domain
{
    public record Bounds
    {
        public int Width { get; }
        public int Height { get; }
        public Bounds(int size) => (Width, Height) = (size, size);
        public bool IsCorner(int index) =>
            index == 0 || index == Width - 1 ||
            index == Width * Height - Width ||
            index == Width * Height - 1;
    }
}
