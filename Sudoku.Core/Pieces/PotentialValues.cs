namespace Sudoku.Core.Pieces
{
    using System.Collections.Generic;
    using System.Linq;

    public class PotentialValues
    {
        private readonly List<int> potentials = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }.ToList();

        public virtual List<int> Possible => this.potentials;

        public virtual void Remove(int value)
        {
            this.potentials.Remove(value);
        }
    }

    public class EmptyPotentialValues : PotentialValues
    {
        public override List<int> Possible { get; } = new List<int>();

        public override void Remove(int value)
        {
        }
    }
}