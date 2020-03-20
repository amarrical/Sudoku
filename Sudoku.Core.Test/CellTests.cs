namespace Sudoku.Core.Test
{
    using FluentAssertions;

    using Sudoku.Core.Pieces;

    using Xunit;

    public class CellTests
    {
        private Cell target;

        public CellTests()
        {
            this.target = new Cell();
        }

        [Fact]
        public void ValueCannotBeSetIfGameFixed()
        {
            var value = 1;
            var newValue = 4;

            this.target = new Cell(value);
            this.target.Value = newValue;

            var result = this.target.Value;
            result.Should().Be(value);
        }

        [Fact]
        public void ToStringReturnsNumberIfSet()
        {
            var result = this.target.ToString();

            result.Should().Be(" ");
        }
    }
}