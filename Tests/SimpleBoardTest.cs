namespace Tests
{
    using NUnit.Framework;
    using SudokuSolver;

    [TestFixture]
    public class SimpleBoardTest
    {
        [Test]
        public void CanSolveSimpleBoard()
        {
            Solver solver = new Solver();
            int[,] board = GetSimpleBoardToSolve();

            bool solved = solver.Solve(board);

            // there is a solution to this board
            Assert.IsTrue(solved);
            Assert.GreaterOrEqual(solver.SolutionCount, 1);
        }


        [Test]
        public void SimpleBoardIsConsistent()
        {
            int[,] board = GetSimpleBoardToSolve();

            bool isConsistent = Solver.IsConsistent(board);

            // there is no clash in this board
            Assert.IsTrue(isConsistent);
        }

        private static int[,] GetSimpleBoardToSolve()
        {
            return new int[9, 9] 
            { 
                { 1, 2, 3, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };
        }
    }
}
