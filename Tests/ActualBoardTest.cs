namespace Tests
{
    using NUnit.Framework;
    using SudokuSolver;

    [TestFixture]
    public class ActualBoardTest
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
        public void UnsolvableBoardIsNotConsistent()
        {
            int[,] board = GetUnsolvableBoard();

            bool isConsistent = Solver.IsConsistent(board);

            // there is no solution to this board
            Assert.IsFalse(isConsistent);
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

        private static int[,] GetSampleBoardToSolve()
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
