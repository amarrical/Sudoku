namespace Sudoku.Core.Pieces
{
    using System.Collections.Generic;

    public class Cell
    {
        private int? value;

        private PotentialValues potentials;

        public Cell()
        {
            this.potentials = new PotentialValues();
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
            set => this.SetValue(value);
        }

        public List<int> PotentialValues => this.potentials.Possible;

        public bool OnePossibility => this.PotentialValues.Count == 1;

        public void RemovePotential(int value)
        {
            this.potentials.Remove(value);
        }

        private void SetValue(int? value)
        {
            if (this.GameFixed)
                return;

            this.value = value;
            this.potentials = new EmptyPotentialValues();
        }
    }
}