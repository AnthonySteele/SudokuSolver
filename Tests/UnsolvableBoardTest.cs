namespace Tests
{
    using NUnit.Framework;

    using Sudoku;

    [TestFixture]
    public class UnsolvableBoardTest
    {
        [Test]
        public void UnsolvableBoardIsNotConsistent()
        {
            int[,] board = GetUnsolvableBoard();

            bool isConsistent = Solver.IsConsistent(board);

            // there is no solution to this board
            Assert.IsFalse(isConsistent);
        }

        [Test]
        public void NoSolutionFoundToUnsolvableBoard()
        {
            int[,] board = GetUnsolvableBoard();
            Solver solver = new Solver();
            bool solved = solver.Solve(board);

            Assert.IsFalse(solved);
        }

        private static int[,] GetUnsolvableBoard()
        {
            return new int[9, 9] 
            { 
                { 1, 1, 0, 0, 0, 0, 0, 0, 0 },
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
