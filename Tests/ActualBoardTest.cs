namespace Tests
{
    using NUnit.Framework;
    using SudokuSolver;

    /// <summary>
    /// Test using a board torn from the pages of a discarded newspaper
    /// </summary>
    [TestFixture]
    public class ActualBoardTest
    {
        [Test]
        public void SampleBoardIsConsistent()
        {
            int[,] board = GetBoard();

            bool isConsistent = Solver.IsConsistent(board);

            // there is no clash this board
            Assert.IsTrue(isConsistent);
        }

        [Test]
        public void CanSolveSampleBoard()
        {
            int[,] board = GetBoard();

            Solver solver = new Solver();
            bool solved = solver.Solve(board);

            Assert.IsTrue(solved);
        }

        [Test]
        public void SolutionIsValid()
        {
            int[,] board = GetBoard();

            Solver solver = new Solver();
            solver.Solve(board);

            TestHelper.TestSolutionValid(solver.GetFirstSolution());
        }

        private static int[,] GetBoard()
        {
            return new int[9, 9] 
            { 
                { 5, 6, 0, 0, 0, 2, 1, 7, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 4, 9 },
                { 4, 1, 0, 9, 0, 0, 5, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                { 7, 0, 0, 0, 0, 0, 0, 0, 4 },
                { 0, 0, 0, 0, 5, 0, 0, 0, 0 },
                { 0, 0, 7, 0, 0, 4, 0, 2, 8 },
                { 2, 3, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 5, 4, 2, 0, 0, 0, 9, 1 }
            };
        }
    }
}