namespace Sudoku.Core.Pieces
{
    public class Column : LineContainer
    {
        public override Cell[] Cells { get; } = new Cell[9];
    }
}