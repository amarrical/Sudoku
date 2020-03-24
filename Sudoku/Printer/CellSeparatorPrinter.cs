namespace Sudoku.Printer
{
    using System.Collections.Generic;
    using System.Text;

    public class CellSeparatorPrinter
    {
        public List<StringBuilder> Print(List<StringBuilder> lines)
        {
            foreach (var builder in lines)
            {
                builder.Append("|");
            }

            return lines;
        }
    }
}