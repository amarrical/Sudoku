namespace Sudoku.Printer
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Sudoku.Core;
    using Sudoku.Core.Pieces;

    public class RowPrinter
    {
        private CellPrinter CellPrinter = new CellPrinter();

        private CellSeparatorPrinter SeparatorPrinter = new CellSeparatorPrinter();

        public List<StringBuilder> Print(Row row)
        {
            var lines = SudokuFactory.BuildSingle<StringBuilder>(5).ToList();
            lines = this.CellPrinter.Print(row[0], lines);
            lines = this.CellPrinter.Print(row[1], lines);
            lines = this.CellPrinter.Print(row[2], lines);
            lines = this.SeparatorPrinter.Print(lines);
            lines = this.CellPrinter.Print(row[3], lines);
            lines = this.CellPrinter.Print(row[4], lines);
            lines = this.CellPrinter.Print(row[5], lines);
            lines = this.SeparatorPrinter.Print(lines);
            lines = this.CellPrinter.Print(row[6], lines);
            lines = this.CellPrinter.Print(row[7], lines);
            lines = this.CellPrinter.Print(row[8], lines);

            return lines;
        }
    }
}