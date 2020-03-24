namespace Sudoku.Core.Pieces
{
    using System.Linq;

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