// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SudokuSolver.cs" company="AFS">
//  Copyright AFS
// </copyright>
// <summary>
//   solve a Sudoku grid by brute force and ignorance
//   i.e. depth-first exhaustive search
//   It works, and quickly too: under 0.5 seconds
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sudoku
{
    /// <summary>
    /// solve a Sudoku grid
    /// by brute force and ignorance
    /// i.e. depth-first exhaustive search
    /// It works, and quickly too
    /// under 0.5 seconds
    /// </summary>
    public class Solver
    {
        /// <summary>
        /// the board size is also the digit count, 
        /// since all digits occur exactly once in each row and column 
        /// </summary>
        public const int BoardSize = 9;
        
        /// <summary>
        /// we just want to know if the solution is unique, 
        /// we don't care if there are 2 or 2000 solutions
        /// there should only be one 
        /// </summary>
        public const int MaxSolutions = 2;

        /// <summary>
        /// Number of solutions found
        /// </summary>
        private int solutionCount;

        /// <summary>
        /// Details of the primary solution
        /// </summary>
        private int[,] firstSolution;

        /// <summary>
        /// Gets the number of solutions found
        /// </summary>
        public int SolutionCount
        {
            get
            {
                return this.solutionCount;
            }
        }

        /// <summary>
        /// Copy a board
        /// </summary>
        /// <param name="boardData">the board data</param>
        /// <returns>a copy of the board data</returns>
        public static int[,] CopyBoard(int[,] boardData)
        {
            if (boardData == null)
            {
                return null;
            }

            int[,] result = new int[BoardSize, BoardSize];
            for (int ix = 0; ix < BoardSize; ix++)
            {
                for (int iy = 0; iy < BoardSize; iy++)
                {
                    result[ix, iy] = boardData[ix, iy];
                }
            }

            return result;
        }

        /// <summary>
        /// Test the board
        /// </summary>
        /// <param name="boardData">the board to test</param>
        /// <returns>false if the board cannot be solved</returns>
        public static bool IsConsistent(int[,] boardData)
        {
            for (int ix = 0; ix < BoardSize; ix++)
            {
                for (int iy = 0; iy < BoardSize; iy++)
                {
                    if (boardData[ix, iy] > 0)
                    {
                        if (! UniqueInAllWays(boardData, boardData[ix, iy], ix, iy))
                        {
                            // something is inconstent with this cell
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the primary solution 
        /// </summary>
        /// <returns>a copy of the primary solution data</returns>
        public int[,] GetFirstSolution()
        {
            return CopyBoard(this.firstSolution);
        }

        /// <summary>
        /// Solve the board
        /// </summary>
        /// <param name="boardData">the board to solve</param>
        /// <returns>true if a solution can be found</returns>
        public bool Solve(int[,] boardData)
        {
            if (Solver.IsConsistent(boardData))
            {
                this.SolveInternal(boardData);

                return this.solutionCount > 0;
            }

            return false;
        }

        /// <summary>
        /// true if the value is not already found in the row
        /// </summary>
        /// <param name="boardData">the board data</param>
        /// <param name="val">the value to find</param>
        /// <param name="x">x co-ordinate of the value</param>
        /// <param name="y">y co-ordinate of the value</param>
        /// <returns>true if the value is unique in the row</returns>
        private static bool UniqueInRow(int[,] boardData, int val, int x, int y)
        {
            bool result = true;
            for (int i = 0; i < BoardSize; i++)
            {
                if ((i != x) && (boardData[i, y] == val))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// true if the value is not already found in the column
        /// </summary>
        /// <param name="boardData">the board data</param>
        /// <param name="val">the value to find</param>
        /// <param name="x">x co-ordinate of the value</param>
        /// <param name="y">y co-ordinate of the value</param>
        /// <returns>true if the value is unique in the column</returns>
        private static bool UniqueInCol(int[,] boardData, int val, int x, int y)
        {
            bool result = true;
            for (int i = 0; i < BoardSize; i++)
            {
                if ((i != y) && (boardData[x, i] == val))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// true if the value is not already found in the nonstant
        /// The board is divided in 9 parts not 4 -
        /// they are not quadrants so they must be nonstants
        /// </summary>
        /// <param name="boardData">the board data</param>
        /// <param name="val">the value to find</param>
        /// <param name="x">x co-ordinate of the value</param>
        /// <param name="y">y co-ordinate of the value</param>
        /// <returns>true if the value is unique in the board division</returns>
        private static bool UniqueInNonstant(int[,] boardData, int val, int x, int y)
        {
            bool result = true;

            const int NonstantSize = BoardSize / 3;
            int startx = x / 3;
            startx = startx * 3;
            int starty = y / 3;
            starty = starty * 3;

            for (int ix = startx; ix < startx + NonstantSize; ix++)
            {
                for (int iy = starty; iy < starty + NonstantSize; iy++)
                {
                    if ((ix != x) && (iy != y) && (boardData[ix, iy] == val))
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// true if the value is not already found anywhere it shouldn't be
        /// </summary>
        /// <param name="boardData">the board data</param>
        /// <param name="val">the value to find</param>
        /// <param name="x">x co-ordinate of the value</param>
        /// <param name="y">y co-ordinate of the value</param>
        /// <returns>true if the value is unique in all ways</returns>
        private static bool UniqueInAllWays(int[,] boardData, int val, int x, int y)
        {
            return
              UniqueInRow(boardData, val, x, y) &&
              UniqueInCol(boardData, val, x, y) &&
              UniqueInNonstant(boardData, val, x, y);
        }

        /// <summary>
        /// Solve the puzzle
        /// Get a board, try to fill the first empty cell
        /// Return if this can be done with a value that is unique
        /// and can solve further through all other cells
        /// </summary>
        /// <param name="boardData">the board's data</param>
        /// <returns>true if the board can be solved</returns>
        private bool SolveInternal(int[,] boardData)
        {
            for (int ix = 0; ix < BoardSize; ix++)
            {
                for (int iy = 0; iy < BoardSize; iy++)
                {
                    if (boardData[ix, iy] == 0)
                    {
                        return this.SolveCell(boardData, ix, iy);
                    }
                }
            }

            // no cells empty
            return true;
        }

        /// <summary>
        /// solve the empty cell by testing the possible digits in it 
        ///  uses mutual recursion with SolveInternal
        /// </summary>
        /// <param name="boardData">the board data</param>
        /// <param name="x">the cell x co-ordinate</param>
        /// <param name="y">the cell y-coordinate</param>
        /// <returns>true of the cell can be solved</returns>
        private bool SolveCell(int[,] boardData, int x, int y)
        {
            for (int testVal = 1; testVal <= 9; testVal++)
            {
                if (UniqueInAllWays(boardData, testVal, x, y))
                {
                    boardData[x, y] = testVal;
                    if (this.SolveInternal(boardData))
                    {
                        // we have a winner
                        if (this.solutionCount == 0)
                        {
                            this.firstSolution = CopyBoard(boardData);
                        }

                        this.solutionCount++;

                        if (this.solutionCount >= MaxSolutions)
                        {
                            return true;
                        }
                    }
                }
            }

            // failed to find a solution on this path. Back out
            boardData[x, y] = 0;
            return false;
        }
    }
}
