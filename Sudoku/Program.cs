using System;

namespace Sudoku
{
    using System.Linq;

    using Sudoku.Core;
    using Sudoku.Core.Pieces;

    class Program
    {
        static void Main(string[] args)
        {
            var placements = Game1();
            var board = new GameBoard(placements);
            var printer = new BoardPrinter();
            printer.Print(board);
            var solver = new Solver();
            board = solver.SetPossibles(board);
            printer.Print(board);
        }

        private static Placement[] Game1()
        {
            return new[]
                {
                    new Placement(0, 3, 4),
                    new Placement(0, 4, 3),
                    new Placement(0, 5, 8),
                    new Placement(0, 8, 9),

                    new Placement(1, 0, 2),
                    new Placement(1, 1, 4),
                    new Placement(1, 3, 7),
                    new Placement(1, 5, 6),
                    new Placement(1, 6, 5),

                    new Placement(2, 4, 2),
                    new Placement(2, 6, 6),

                    new Placement(3, 0, 4),
                    new Placement(3, 3, 6),
                    new Placement(3, 4, 9),
                    new Placement(3, 7, 2),
                    new Placement(3, 8, 7),

                    new Placement(4, 0, 1),
                    new Placement(4, 1, 5),
                    new Placement(4, 7, 9),
                    new Placement(4, 8, 6),

                    new Placement(5, 0, 7),
                    new Placement(5, 1, 9),
                    new Placement(5, 4, 8),
                    new Placement(5, 5, 2),
                    new Placement(5, 8, 3),

                    new Placement(6, 2, 7),
                    new Placement(6, 4, 6),

                    new Placement(7, 2, 4),
                    new Placement(7, 3, 9),
                    new Placement(7, 5, 3),
                    new Placement(7, 7, 8),
                    new Placement(7, 8, 2),

                    new Placement(8, 0, 3),
                    new Placement(8, 3, 8),
                    new Placement(8, 4, 7),
                    new Placement(8, 5, 4)
                };
        }
    }

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
