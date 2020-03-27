namespace Sudoku
{
    using System;
    using System.Linq;

    using Sudoku.Core;
    using Sudoku.Core.Pieces;
    using Sudoku.Printer;

    class Program
    {
        static void Main(string[] args)
        {
            var placements = GameHard();
            var board = new GameBoard(placements);
            var printer = new BoardPrinter();
            printer.Print(board);
            var solver = new Solver();
            board = solver.Solve(board);
            printer.Print(board);
        }

        private static Placement[] GameEasy()
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

        private static Placement[] GameMedium()
        {
            return new []
                {
                    new Placement(0, 6, 3),
                    new Placement(0, 8, 1),

                    new Placement(1, 1, 8),
                    new Placement(1, 2, 6),
                    new Placement(1, 3, 7),
                    new Placement(1, 4, 9),

                    new Placement(2, 1, 5),
                    new Placement(2, 2, 1),
                    new Placement(2, 3, 3),
                    new Placement(2, 7, 6),

                    new Placement(3, 0, 7),
                    new Placement(3, 3, 4),
                    new Placement(3, 4, 8),

                    new Placement(4, 0, 4),
                    new Placement(4, 2, 8),
                    new Placement(4, 6, 2),
                    new Placement(4, 8, 6),

                    new Placement(5, 4, 1),
                    new Placement(5, 5, 7),
                    new Placement(5, 8, 8),

                    new Placement(6, 1, 3),
                    new Placement(6, 5, 9),
                    new Placement(6, 6, 7),
                    new Placement(6, 7, 5),

                    new Placement(7, 4, 7),
                    new Placement(7, 5, 2),
                    new Placement(7, 6, 8),
                    new Placement(7, 7, 3),

                    new Placement(8, 0, 8),
                    new Placement(8, 2, 9)
                };
        }

        private static Placement[] GameHard()
        {

            return new[]
                {
                    new Placement(0, 1, 5),
                    new Placement(0, 2, 2),
                    new Placement(0, 3, 3),
                    new Placement(0, 7, 4),

                    new Placement(1, 3, 4),
                    new Placement(1, 4, 9),
                    new Placement(1, 6, 8),

                    new Placement(2, 0, 8),
                    new Placement(2, 1, 6),
                    new Placement(2, 5, 5),

                    new Placement(3, 0, 2),
                    new Placement(3, 7, 9),
                    new Placement(3, 8, 4),

                    new Placement(4, 4, 6),

                    new Placement(5, 0, 5),
                    new Placement(5, 1, 9),
                    new Placement(5, 8, 2),

                    new Placement(6, 3, 9),
                    new Placement(6, 7, 2),
                    new Placement(6, 8, 8),

                    new Placement(7, 2, 9),
                    new Placement(7, 4, 5),
                    new Placement(7, 5, 7),

                    new Placement(8, 1, 3),
                    new Placement(8, 5, 4),
                    new Placement(8, 6, 9),
                    new Placement(8, 7, 5),
                };
        }
    }
}
