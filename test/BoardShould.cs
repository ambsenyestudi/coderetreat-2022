using ConwaysGameOfLife.Domain;
using ConwaysGameOfLife.Domain.Cells;

namespace ConwaysGameOfLife.Test
{
    public class BoardShould
    {
        [Fact]
        public void NotHaveLessCellsThanNeeded()
        {
            Assert.Throws<CellAmountException>(() => new Board(2, new List<Cell>()));
        }

        [Fact]
        public void HaveNeededCells()
        {
            var board = new Board(2, new List<Cell> { 
                new Cell(false),
                new Cell(true), 
                new Cell(false),
                new Cell(true)
            });
            Assert.Equal(4, board.Cells.Count);
        }
    }
}
