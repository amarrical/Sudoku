namespace Sudoku.Core.Pieces
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class Cell
    {
        private int? value;

        private PotentialValues potentials = new PotentialValues();

        public Cell()
        {
        }

        public Cell(int value)
        {
            this.GameFixed = true;
            this.value = value;
            this.potentials = new EmptyPotentialValues();
        }

        public bool GameFixed { get; }

        public bool Set => this.value.HasValue;

        public int? Value
        {
            get => this.value;
            set => this.value = (this.GameFixed) ? this.value : value;
        }

        public bool HasValue => this.value.HasValue;

        public List<int> PotentialValues => this.potentials.Possible;

        public bool OnePossibility => this.PotentialValues.Count == 1;

        public void RemovePotential(int value)
        {
            this.potentials.Remove(value);
        }

        public override string ToString()
        {
            return (this.OnePossibility)
                ? "X"
                : this.value.GetValueOrDefault(0).ToString().Replace('0', ' ');
        }
    }
}