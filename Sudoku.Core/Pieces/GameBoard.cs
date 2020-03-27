namespace Sudoku.Core.Pieces
{
    using System.Collections.Generic;
    using System.Linq;

    public class GameBoard
    {
        private readonly List<List<Cell>> contents = SudokuFactory.BuildDouble<Cell>(9);

        private readonly List<List<SubGrid>> subGrids = SudokuFactory.BuildDouble<SubGrid>();

        public GameBoard()
        {
            this.Rows = SudokuFactory.BuildSingle<Row>().ToList();
            this.Columns = SudokuFactory.BuildSingle<Column>().ToList();
            this.subGrids = SudokuFactory.BuildDouble<SubGrid>();
            this.AlignCollections();
        }

        public GameBoard(IEnumerable<Placement> initialValues)
            : this()
        {
            initialValues.ToList().ForEach(p => this[p.Row, p.Column] = new Cell(p.Value));
        }

        public List<Row> Rows { get; }

        public List<Column> Columns { get; }

        public List<SubGrid> SubGrids => this.subGrids.SelectMany(_ => _).ToList();

        public Cell this[int row, int column]
        {
            get => this.contents[row][column];
            set => this.SetCell(row, column, value);
        }

        public List<Cell> Cells
        {
            get
            {
                var cells = new List<Cell>();
                this.Rows.ToList().ForEach(r => cells.AddRange(r.Cells));
                return cells;
            }
        }

        private void AlignCollections()
        {
            for (var row = 0; row < 9; row++)
                for (var column = 0; column < 9; column++)
                    this.SetCell(row, column, this[row, column]);
        }

        private void SetCell(int row, int column, Cell cell)
        {
            this.contents[row][column] = cell;
            this.Rows[row][column] = cell;
            this.Columns[column][row] = cell;
            this.subGrids[row / 3][column / 3][row % 3, column % 3] = cell;
        }
    }
}