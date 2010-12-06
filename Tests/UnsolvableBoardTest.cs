namespace Tests
{
    using NUnit.Framework;
    using SudokuSolver;

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
