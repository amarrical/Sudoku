namespace Sudoku.Printer
{
    using System.Text;

    public class RowSeparatorPrinter
    {
        public StringBuilder Print()
        {
            return new StringBuilder("-----------------------------------------------");
        }
    }
}