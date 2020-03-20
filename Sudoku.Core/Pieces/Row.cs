namespace Sudoku.Core.Pieces
{
    using System.Collections.Generic;
    using System.Linq;

    public class Row : LineContainer
    {
        public override Cell[] Cells { get; } = new Cell[9];

        public override string ToString()
        {
            return $"{this.Cells[0]}{this.Cells[1]}{this.Cells[2]}|"
                   + $"{this.Cells[3]}{this.Cells[4]}{this.Cells[5]}|"
                   + $"{this.Cells[6]}{this.Cells[7]}{this.Cells[8]}";
        }
    }

    public abstract class LineContainer
    {
        public abstract Cell[] Cells { get; }

        public bool HasValue => this.Cells.Any(c => c.HasValue);

        public Cell this[int key]
        {
            get => this.Cells[key];
            set => this.Cells[key] = value;
        }

        public void RemovePotentials(int? value)
        {
            if (!value.HasValue)
                return;

            foreach (var cell in this.Cells)
                cell.RemovePotential(value.Value);
        }
    }
}