namespace Sudoku.Core.Pieces
{
    using System.Collections.Generic;
    using System.Linq;

    public class GameBoard
    {
        private readonly Cell[,] contents = new Cell[9, 9];

        public GameBoard()
        {
            this.Rows = SudokuFactory.BuildSingle<Row>();
            this.Columns = SudokuFactory.BuildSingle<Column>();
            this.SubGrids = SudokuFactory.BuildDouble<SubGrid>();
            this.LoadContents();
        }

        public GameBoard(IEnumerable<Placement> initialValues)
            : this()
        {
            initialValues.ToList().ForEach(p => this[p.Row, p.Column] = new Cell(p.Value));
        }

        public Row[] Rows { get; }

        public Column[] Columns { get; }

        public SubGrid[,] SubGrids { get; }

        public Cell this[int row, int column]
        {
            get => this.contents[row, column];
            set => this.SetCell(row, column, value);
        }

        private void LoadContents()
        {
            for (var row = 0; row < 9; row++)
                for (var column = 0; column < 9; column++)
                    this[row, column] = new Cell();
        }

        private void SetCell(int row, int column, Cell cell)
        {
            this.contents[row, column] = cell;
            this.Rows[row][column] = cell;
            this.Columns[column][row] = cell;
            this.SubGrids[row / 3, column / 3][row % 3, column % 3] = cell;
        }
    }
}