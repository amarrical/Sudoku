namespace Sudoku.Core
{
    using System.Collections.Generic;
    using System.Linq;

    public static class SudokuFactory
    {
        public static List<T> BuildSingle<T>(int length = 9)
            where T : new()
        {
            return Enumerable.Range(0, length).Select(_ => new T()).ToList();
        }

        public static List<List<T>> BuildDouble<T>(int side = 3)
            where T : new()
        {
            return Enumerable.Range(0, side).Select(_ => BuildSingle<T>(side)).ToList();
        }
    }
}