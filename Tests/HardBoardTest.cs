namespace Tests
{
    using System;
    using System.Diagnostics;

    using NUnit.Framework;
    using SudokuSolver;

    /// <summary>
    /// Test using a "hard" board from http://www.forbeginners.info/sudoku-puzzles/hard-1.htm
    /// </summary>
    [TestFixture]
    public class HardBoardTest
    {
        [Test]
        public void CanSolveBoard()
        {
            Solver solver = new Solver();
            int[,] board = GetBoard();

            bool solved = solver.Solve(board);

            // there is a solution to this board
            Assert.IsTrue(solved);
            Assert.AreEqual(1, solver.SolutionCount);
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
        [Ignore("used to time the solving")]
        public void TimeSolution()
        {
            Solver solver = new Solver();
            int[,] board = GetBoard();

            Stopwatch timer = new Stopwatch();
            timer.Start();
            solver.Solve(board);
            timer.Stop();

            TimeSpan timeToSolve = timer.Elapsed;

            Assert.Fail("Solving took " + timeToSolve);
        }

        private static int[,] GetBoard()
        {
            return new int[9, 9] 
            { 
                { 0, 0, 0, 2, 0, 0, 0, 6, 3 },
                { 3, 0, 0, 0, 0, 5, 4, 0, 1 },
                { 0, 0, 1, 0, 0, 3, 9, 8, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 9, 0 },
                { 0, 0, 0, 5, 3, 8, 0, 0, 0 },
                { 0, 3, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 2, 6, 3, 0, 0, 5, 0, 0 },
                { 5, 0, 3, 7, 0, 0, 0, 0, 8 },
                { 4, 7, 0, 0, 0, 1, 0, 0, 0 }
            };
        }

        private static int[,] GetBoardSolution()
        {
            return new int[9, 9] 
            { 
                { 8, 5, 4, 2, 1, 9, 7, 6, 3 },
                { 3, 9, 7, 8, 6, 5, 4, 2, 1 },
                { 2, 6, 1, 4, 7, 3, 9, 8, 5 },
                { 7, 8, 5, 1, 2, 6, 3, 9, 4 },
                { 6, 4, 9, 5, 3, 8, 1, 7, 2 },
                { 1, 3, 2, 9, 4, 7, 8, 5, 6 },
                { 9, 2, 6, 3, 8, 4, 5, 1, 7 },
                { 5, 1, 3, 7, 9, 2, 6, 4, 8 },
                { 4, 7, 8, 6, 5, 1, 2, 3, 9 }
            };
        }
    }
}
