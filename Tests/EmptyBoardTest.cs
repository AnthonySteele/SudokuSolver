namespace Tests
{
    using NUnit.Framework;
    using SudokuSolver;

    [TestFixture]
    public class EmptyBoardTest
    {
        [Test]
        public void EmptyBoardIsConsistent()
        {
            int[,] board = new int[9, 9];

            bool isConsistent = Solver.IsConsistent(board);

            // there are no clashes in an empty board
            Assert.IsTrue(isConsistent);
        }
        [Test]
        public void CanSolveEmptyBoard()
        {
            Solver solver = new Solver();
            int[,] board = new int[9, 9];

            bool solved = solver.Solve(board);

            // there are solutions to an empty board
            Assert.IsTrue(solved);
        }

        [Test]
        public void EmptyBoardSolutionIsValid()
        {
            int[,] board = new int[9, 9];
            Solver solver = new Solver();

            solver.Solve(board);
            int[,] firstSolution = solver.GetFirstSolution();

            TestHelper.TestSolutionValid(firstSolution);
        }
    }
}
