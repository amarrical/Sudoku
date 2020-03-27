namespace Sudoku.Core.Pieces
{
    public class Row : LineContainer
    {
        public override Cell[] Cells { get; } = new Cell[9];
    }
}