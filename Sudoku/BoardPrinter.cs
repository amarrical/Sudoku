namespace Sudoku
{
    using System;
    using System.Linq;

    using Sudoku.Core.Pieces;

    public class BoardPrinter
    {
        public void Print(GameBoard board)
        {
            var boardState = new[]
                {
                    string.Empty,
                    board.Rows[0].ToString(),
                    board.Rows[1].ToString(),
                    board.Rows[2].ToString(),
                    "-----------",
                    board.Rows[3].ToString(),
                    board.Rows[4].ToString(),
                    board.Rows[5].ToString(),
                    "-----------",
                    board.Rows[6].ToString(),
                    board.Rows[7].ToString(),
                    board.Rows[8].ToString(),
                };

            boardState.ToList().ForEach(Console.WriteLine);
        }
    }
}