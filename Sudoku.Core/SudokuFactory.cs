namespace Sudoku.Core
{
    using System.Linq;

    public static class SudokuFactory
    {
        public static T[] BuildSingle<T>(int length = 9)
            where T : new()
        {
            return Enumerable.Range(0, length).Select(_ => new T()).ToArray();
        }

        public static T[,] BuildDouble<T>(int side = 3)
            where T : new()
        {
            var result = new T[side, side];
            for (var i = 0; i < side; i++)
                for (var j = 0; j < side; j++)
                    result[i, j] = new T();

            return result;
        }
    }
}