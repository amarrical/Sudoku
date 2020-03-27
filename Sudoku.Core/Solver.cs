namespace Sudoku.Core
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;

    using ARM.Extensions;

    using Sudoku.Core.Pieces;

    public class Solver
    {
        private const int TotalCellCount = 81;

        public GameBoard Solve(GameBoard gameBoard)
        {
            return this.SolveLoop(gameBoard, SolveBoard);

            GameBoard SolveBoard(GameBoard board)
            {
                board = this.SetCellOnlyPossibility(board);
                board = this.SetOnlyInstanceOfPossibilityInContainer(board);
                return board;
            }
        }

        public GameBoard SetCellPosibilities(GameBoard board)
        {
            board.Rows.Where(_ => _.HasValue).ForEach(row => row.Cells.Where(_ => _.Set).ForEach(c => row.RemovePotentials(c.Value)));
            board.Columns.Where(_ => _.HasValue).ForEach(col => col.Cells.Where(_ => _.Set).ForEach(c => col.RemovePotentials(c.Value)));
            board.SubGrids.Where(_ => _.HasValue).ForEach(sub => sub.Cells.Where(_ => _.Set).ForEach(c => sub.RemovePotentials(c.Value)));
            return board;
        }

        public GameBoard SetCellOnlyPossibility(GameBoard gameBoard)
        {
            return this.SolveLoop(gameBoard, SolveOnlyPossibility);

            GameBoard SolveOnlyPossibility(GameBoard board)
            {
                board = this.SetCellPosibilities(board);
                board.Cells.Where(c => c.OnePossibility).ForEach(c => c.Value = c.PotentialValues.First());
                return board;
            }
        }

        public GameBoard SetOnlyInstanceOfPossibilityInContainer(GameBoard gameBoard)
        {
            return this.SolveLoop(gameBoard, SolveOnlyOneInContainer);

            GameBoard SolveOnlyOneInContainer(GameBoard board)
            {
                board = this.SetCellPosibilities(board);
                var possibleValues = Enumerable.Range(1, 9).ToList();
                foreach (var value in possibleValues)
                {
                    board = this.SetCellPosibilities(board);
                    foreach (var row in board.Rows.Where(row => row.Cells.Count(c => c.PotentialValues.Contains(value)) == 1))
                    {
                        row.Cells.Single(c => c.PotentialValues.Contains(value)).Value = value;
                    }

                    board = this.SetCellPosibilities(board);
                    foreach (var col in board.Columns.Where(row => row.Cells.Count(c => c.PotentialValues.Contains(value)) == 1))
                    {
                        col.Cells.Single(c => c.PotentialValues.Contains(value)).Value = value;
                    }

                    board = this.SetCellPosibilities(board);
                    foreach (var sub in board.SubGrids.Where(row => row.Cells.Count(c => c.PotentialValues.Contains(value)) == 1))
                    {
                        sub.Cells.Single(c => c.PotentialValues.Contains(value)).Value = value;
                    }
                }

                return board;
            }
        }

        private GameBoard SolveLoop(GameBoard board, Func<GameBoard, GameBoard> solutionStep)
        {
            var solvedCount = 0;
            var newSolvedCount = board.Cells.Count(c => c.Set);
            do
            {
                solvedCount = newSolvedCount;
                board = solutionStep.Invoke(board);
                newSolvedCount = board.Cells.Count(c => c.Set);
                if (solvedCount == TotalCellCount)
                    break;
            }
            while (newSolvedCount > solvedCount);

            return board;
        }
    }
}