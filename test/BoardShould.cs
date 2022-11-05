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
    }
}
