namespace Sudoku.Core.Pieces
{
    using System.Collections.Generic;
    using System.Linq;

    public class SubGrid
    {
        private List<List<Cell>> cells = SudokuFactory.BuildDouble<Cell>();

        public Cell this[int column, int row]
        {
            get => this.cells[column][row];
            set => this.cells[column][row] = value;
        }

        public List<Cell> Cells => this.cells.SelectMany(_ => _).ToList();

        public bool HasValue => this.Cells.Any(_ => _.Set);

        public void RemovePotentials(int? value)
        {
            if (!value.HasValue)
                return;

            this.Cells.ForEach(_ => _.RemovePotential(value.Value));
        }
    }
}