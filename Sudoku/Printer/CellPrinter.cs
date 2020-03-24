namespace Sudoku.Printer
{
    using System.Collections.Generic;
    using System.Text;

    using Sudoku.Core.Pieces;

    public class CellPrinter
    {
        public List<StringBuilder> Print(Cell cell, List<StringBuilder> lines)
        {
            if (cell.Set) 
                lines = cell.GameFixed 
                    ? this.PrintFixed(cell.Value, lines) 
                    : this.PrintSolved(cell.Value, lines);
            else
                lines = this.PrintOpen(cell.PotentialValues, lines);

            return lines;
        }

        private List<StringBuilder> PrintFixed(int? value, List<StringBuilder> lines)
        {
            lines[0].Append("     ");
            lines[1].Append($" {value}{value}{value} ");
            lines[2].Append($" {value}{value}{value} ");
            lines[3].Append($" {value}{value}{value} ");
            lines[4].Append("     ");
            return lines;
        }

        private List<StringBuilder> PrintSolved(int? value, List<StringBuilder> lines)
        {
            lines[0].Append("     ");
            lines[1].Append(" X X ");
            lines[2].Append($"  {value}  ");
            lines[3].Append(" X X ");
            lines[4].Append("     ");
            return lines;
        }

        private List<StringBuilder> PrintOpen(List<int> potentials, List<StringBuilder> lines)
        {
            lines[0].Append("     ");
            lines[1].Append($" {this.PrintPossible(1, potentials)}{this.PrintPossible(2, potentials)}{this.PrintPossible(3, potentials)} ");
            lines[2].Append($" {this.PrintPossible(4, potentials)}{this.PrintPossible(5, potentials)}{this.PrintPossible(6, potentials)} ");
            lines[3].Append($" {this.PrintPossible(7, potentials)}{this.PrintPossible(8, potentials)}{this.PrintPossible(9, potentials)} ");
            lines[4].Append("     ");
            return lines;
        }

        private string PrintPossible(int value, List<int> potentials)
        {
            return potentials.Contains(value)
                ? value.ToString()
                : " ";
        }
    }
}