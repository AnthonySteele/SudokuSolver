﻿namespace Tests
{
    using NUnit.Framework;

    using Sudoku;

    /// <summary>
    /// Puzzle one from http://www.educationworld.com/a_lesson/sudoku/sudoku001.shtml
    /// </summary>
    public class PuzzleOneTest
    {
        [Test]
        public void CanSolveSimpleBoard()
        {
            Solver solver = new Solver();
            int[,] board = GetBoard();

            bool solved = solver.Solve(board);

            // there is a solution to this board
            Assert.IsTrue(solved);
            Assert.GreaterOrEqual(solver.SolutionCount, 1);
        }

        [Test]
        public void SolutionIsCorrect()
        {
            Solver solver = new Solver();
            int[,] board = GetBoard();

            solver.Solve(board);

            int[,] solution = solver.GetFirstSolution();

            TestHelper.TestSolutionValid(solution);
            TestHelper.BoardsAreSameInFilledCells(solution, GetBoardSolution());
        }

        [Test]
        public void SimpleBoardIsConsistent()
        {
            int[,] board = GetBoard();

            bool isConsistent = Solver.IsConsistent(board);

            // there is no clash in this board
            Assert.IsTrue(isConsistent);
        }

        [Test]
        public void SolutionIsValid()
        {
            Assert.IsTrue(Solver.IsConsistent(GetBoardSolution()));
            TestHelper.TestSolutionValid(GetBoardSolution());
        }

        [Test]
        public void SolutionMatchesProblem()
        {
            Assert.IsTrue(TestHelper.BoardsAreSameInFilledCells(GetBoard(), GetBoardSolution()));
        }

        private static int[,] GetBoard()
        {
            return new int[9, 9] 
            { 
                { 0, 3, 4, 0, 0, 6, 0, 0, 7 },
                { 0, 0, 7, 8, 1, 0, 0, 6, 0 },
                { 1, 8, 6, 3, 0, 2, 4, 5, 0 },
                { 0, 0, 9, 6, 8, 0, 0, 0, 2 },
                { 6, 0, 0, 0, 0, 0, 0, 0, 4 },
                { 7, 0, 0, 0, 9, 5, 6, 0, 0 },
                { 0, 9, 2, 5, 0, 7, 1, 4, 8 },
                { 0, 7, 0, 0, 3, 8, 9, 0, 0 },
                { 8, 0, 0, 2, 0, 0, 3, 7, 0 }
            };
        }

        private static int[,] GetBoardSolution()
        {
            return new int[9, 9] 
            { 
                { 2, 3, 4, 9, 5, 6, 8, 1, 7 },
                { 9, 5, 7, 8, 1, 4, 2, 6, 3 },
                { 1, 8, 6, 3, 7, 2, 4, 5, 9 },
                { 5, 4, 9, 6, 8, 1, 7, 3, 2 },
                { 6, 1, 8, 7, 2, 3, 5, 9, 4 },
                { 7, 2, 3, 4, 9, 5, 6, 8, 1 },
                { 3, 9, 2, 5, 6, 7, 1, 4, 8 },
                { 4, 7, 5, 1, 3, 8, 9, 2, 6 },
                { 8, 6, 1, 2, 4, 9, 3, 7, 5 }
            };
        }
    }
}
