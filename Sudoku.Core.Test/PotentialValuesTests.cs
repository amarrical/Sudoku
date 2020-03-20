namespace Sudoku.Core.Test
{
    using System;
    using System.Linq;

    using FluentAssertions;

    using Sudoku.Core.Pieces;

    using Xunit;

    public class PotentialValuesTests
    {
        private PotentialValues target;

        public PotentialValuesTests()
        {
            this.target = new PotentialValues();
        }

        [Fact]
        public void PossibleReturns9Possibilities()
        {
            var result = this.target.Possible;

            result.Should().HaveCount(9);
            result.Min().Should().Be(1);
            result.Distinct().Should().HaveCount(9);
            result.Max().Should().Be(9);
        }

        [Fact]
        public void ValuesCanBeRemoved()
        {
            var removed = new Random().Next(1, 9);
            this.target.Remove(removed);

            var result = this.target.Possible;

            result.Should().HaveCount(8);
            result.Where(p => p == removed).Should().HaveCount(0);
        }

        [Fact]
        public void ValuesCanBeRemovedTwiceWithoutError()
        {
            var removed = new Random().Next(1, 9);
            this.target.Remove(removed);
            this.target.Remove(removed);

            var result = this.target.Possible;

            result.Should().HaveCount(8);
            result.Where(p => p == removed).Should().HaveCount(0);
        }
    }
}