namespace Sudoku.Core.Pieces
{
    using System.Linq;

    using ARM.Extensions;

    public abstract class LineContainer
    {
        public abstract Cell[] Cells { get; }

        public bool HasValue => this.Cells.Any(c => c.Set);

        public Cell this[int key]
        {
            get => this.Cells[key];
            set => this.Cells[key] = value;
        }

        public void RemovePotentials(int? value)
        {
            if (!value.HasValue)
                return;

            this.Cells.ForEach(_ => _.RemovePotential(value.Value));
        }
    }
}