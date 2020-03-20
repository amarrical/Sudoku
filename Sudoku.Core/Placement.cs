namespace Sudoku.Core
{
    public class Placement
    {
        public Placement(int row, int column, int value)
        {
            this.Row = row;
            this.Column = column;
            this.Value = value;
        }

        public int Row { get; set; }

        public int Column { get; set; }

        public int Value { get; set; }
    }
}