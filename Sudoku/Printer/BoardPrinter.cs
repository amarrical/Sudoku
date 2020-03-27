namespace Sudoku.Printer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Sudoku.Core.Pieces;

    public class BoardPrinter
    {
        private RowPrinter rowPrinter = new RowPrinter();

        private RowSeparatorPrinter separatorPrinter = new RowSeparatorPrinter();

        public void Print(GameBoard board)
        {
            var lines = new List<StringBuilder>();
            lines.AddRange(this.rowPrinter.Print(board.Rows[0]));
            lines.AddRange(this.rowPrinter.Print(board.Rows[1]));
            lines.AddRange(this.rowPrinter.Print(board.Rows[2]));

            lines.Add(this.separatorPrinter.Print());

            lines.AddRange(this.rowPrinter.Print(board.Rows[3]));
            lines.AddRange(this.rowPrinter.Print(board.Rows[4]));
            lines.AddRange(this.rowPrinter.Print(board.Rows[5]));

            lines.Add(this.separatorPrinter.Print());

            lines.AddRange(this.rowPrinter.Print(board.Rows[6]));
            lines.AddRange(this.rowPrinter.Print(board.Rows[7]));
            lines.AddRange(this.rowPrinter.Print(board.Rows[8]));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            lines.ToList().ForEach(Console.WriteLine);
        }
    }
}