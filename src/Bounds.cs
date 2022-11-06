namespace ConwaysGameOfLife.Domain
{
    public record Bounds
    {
        public int Width { get; }
        public int Height { get; }
        public Bounds(int size) => (Width, Height) = (size, size);
        public bool IsCorner(int index) =>
            index == GetTopLeft() || index == GetTopRight() ||
            index == GetBottomLeft() || index == GetBottomRight();

        public int GetBottomRight() => Width * Height - 1;

        public int GetBottomLeft() => Width * Height - Width;

        public int GetTopRight() => Width - 1;

        public int GetTopLeft() => 0;
    }
}
