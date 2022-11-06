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

        [Theory]
        [InlineData(0,1,2,3)]
        public void GetNeighours(int index, params int[] exptectedIndexes)
        {
            var board = new BoardBuilder().WithSize(2)
            .WithCellStates(
            false, true,
            false, true).Build();
            var neighbours = board.GetNeighours(index);
            Assert.Equal(exptectedIndexes,
                neighbours.Select(x => x.Id).ToArray());
        }

    }
}
