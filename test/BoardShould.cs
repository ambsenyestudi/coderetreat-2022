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
        [InlineData( 4, 0, 1, 2, 3, 5, 6, 7, 8)]
        [InlineData( 0, 1, 3, 4)]
        [InlineData( 2, 1, 4, 5)]
        [InlineData( 6, 3, 4, 7)]
        [InlineData( 8, 4, 6, 7)]
        public void GetNeighours(int index, params int[] exptectedIndexes)
        {
            var board = new BoardBuilder().WithSize(3)
            .WithCellStates(
            false, true, true,
            false, true, false,
            true, false, true).Build();
            var neighbours = board.GetNeighours(index);
            Assert.Equal(exptectedIndexes,
                neighbours.Select(x => x.Id).ToArray());
        }

    }
}
