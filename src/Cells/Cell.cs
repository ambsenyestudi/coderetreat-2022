namespace ConwaysGameOfLife.Domain.Cells
{
    public class Cell
    {
        public int Id { get; }
        public bool IsAlive { get; }
        public Cell(int id, bool isAlive)
        {
            Id = id;
            IsAlive = isAlive;
        }

    }
}
