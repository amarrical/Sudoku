namespace Sudoku.Core.Pieces
{
    using System.Collections.Generic;

    public class Row : LineContainer
    {
        public override Cell[] Cells { get; } = new Cell[9];
    }
}