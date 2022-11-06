namespace ConwaysGameOfLife.Domain.Cells
{
    public class Cell
    {
        public bool IsAlive { get; }
        public Cell(bool isAlive)
        {
            IsAlive = isAlive;
        }

    }
}
