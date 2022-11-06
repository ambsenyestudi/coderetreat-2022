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
            var board = new BoardBuilder().WithSize(2)
            .WithCellStates(
            false, true,
            false, true).Build();
            Assert.Equal(4, board.Cells.Count);
        }

        [Fact]
        public void GetNeighours()
        {

        }

    }
}
