using ConwaysGameOfLife.Domain;
using ConwaysGameOfLife.Domain.Cells;

namespace ConwaysGameOfLife.Test
{
    public class BoardBuilder
    {
        private int size;
        private bool[] cellStates = new bool[0];

        public BoardBuilder WithSize(int size)
        {
            this.size = size;
            return this;
        }
        public BoardBuilder WithCellStates(params bool[] cellStates)
        {
            this.cellStates = cellStates;
            return this;
        }
        public Board Build() =>
            new Board(size,
                cellStates.Select((x, i) => new Cell(x)).ToList());
    }
}
