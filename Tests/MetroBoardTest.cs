namespace Tests
{
    using System;
    using System.Diagnostics;

    using NUnit.Framework;

    using Sudoku;

    /// <summary>
    /// Test using a board from the Metro newspaper (Monday 18 July 20111, challenging puzzle) 
    /// that Ann found hard to solve manually
    /// </summary>
    [TestFixture]
    public class MetroBoardTest
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

        private static int[,] GetBoard()
        {
            return new[,] 
            { 
                { 0, 6, 0, 0, 9, 7, 3, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 9 },
                { 5, 0, 4, 6, 0, 0, 0, 2, 0 },
                { 0, 0, 7, 0, 0, 0, 0, 5, 0 },
                { 8, 0, 2, 0, 3, 0, 6, 0, 1 },
                { 0, 1, 0, 0, 0, 0, 8, 0, 0 },
                { 0, 8, 0, 0, 0, 1, 9, 0, 2 },
                { 3, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 6, 5, 7, 0, 0, 0, 0 }
            };
        }
    }
}
