namespace Sudoku.Core.Pieces
{
    using System.Collections.Generic;

    public class SubGrid
    {
        public Cell this[int column, int row]
        {
            get => this.Cells[column, row];
            set => this.Cells[column, row] = value;
        }

        public readonly Cell[,] Cells = new Cell[3, 3];

        public bool HasValue
        {
            get
            {
                foreach (var cell in this.Cells)
                    if (cell.HasValue)
                        return true;

                return false;
            }
        }

        public List<int> ValuesSet
        {
            get
            {
                var values = new List<int>();
                foreach (var cell in this.Cells)
                    if (cell.HasValue)
                        values.Add(cell.Value.Value);

                return values;
            }
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