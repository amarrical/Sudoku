namespace Sudoku.Core
{
    using System.Linq;

    using Sudoku.Core.Pieces;

    public class Solver
    {
        public GameBoard Solve(GameBoard board)
        {
            board = this.SetPossibles(board);
            return board;
        }

        public GameBoard SetPossibles(GameBoard board)
        {
            foreach (var row in board.Rows)
            {
                if (row.HasValue)
                    foreach (var cell in row.Cells.Where(c => c.HasValue))
                        row.RemovePotentials(cell.Value);
            }

            foreach (var column in board.Columns)
            {
                if (column.HasValue)
                    foreach (var cell in column.Cells.Where(c => c.HasValue))
                        column.RemovePotentials(cell.Value);
            }

            foreach (var subGrid in board.SubGrids)
            {
                if (subGrid.HasValue)
                    subGrid.ValuesSet.ForEach(v => subGrid.RemovePotentials(v));
            }

            return board;
        }
    }
}