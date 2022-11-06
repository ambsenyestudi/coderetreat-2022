using ConwaysGameOfLife.Domain;
using ConwaysGameOfLife.Domain.Cells;

namespace ConwaysGameOfLife.Test
{
    public class NeighbourServiceShould
    {
        [Theory]
        [InlineData(4, 0, 1, 2, 3, 5, 6, 7, 8)]
        [InlineData(0, 1, 3, 4)]
        [InlineData(2, 1, 4, 5)]
        [InlineData(6, 3, 4, 7)]
        [InlineData(8, 4, 5, 7)]
        public void GetNeighours(int index, params int[] exptectedIndexes)
        {
            var bounds = new Bounds(3);
            var neighboursIndexes = NeighbourService.GetNeighboursIndexes(bounds, index);
            Assert.Equal(exptectedIndexes,
                neighboursIndexes);
        }
    }
}
