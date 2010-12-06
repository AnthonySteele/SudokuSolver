namespace Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    public static class TestHelper
    {
        public static bool BoardsAreSameInFilledCells(int[,] board, int[,] solvedBoard)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (board[x, y] != 0)
                    {
                        if (board[x, y] != solvedBoard[x, y])
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static void TestSolutionValid(int[,] solvedBoard)
        {
            foreach (int value in solvedBoard)
            {
                Assert.Greater(value, 0);
                Assert.Less(value, 10);
            }

            TestValuesAreUniqueInColumn(solvedBoard);
            TestValuesAreUniqueInRow(solvedBoard);
            TestValuesAreUniqueInNonstants(solvedBoard);
        }

        private static void TestValuesAreUniqueInRow(int[,] solvedBoard)
        {
            for (int y = 0; y < 9; y++)
            {
                List<int> rowValues = new List<int>();
                for (int x = 0; x < 9; x++)
                {
                    // a cell's value has not occured before in the row
                    int newValue = solvedBoard[x, y];
                    Assert.IsFalse(rowValues.Contains(newValue), "Found duplicate cell value " + newValue + " in row");
                    rowValues.Add(newValue);
                }
            }
        }

        private static void TestValuesAreUniqueInColumn(int[,] solvedBoard)
        {
            for (int x = 0; x < 9; x++)
            {
                List<int> columnValues = new List<int>();
                for (int y = 0; y < 9; y++)
                {
                    // a cell's value has not occured before in the column
                    int newValue = solvedBoard[x, y];
                    Assert.IsFalse(columnValues.Contains(newValue), "Found duplicate cell value " + newValue + " in column");
                    columnValues.Add(newValue);
                }
            }
        }

        private static void TestValuesAreUniqueInNonstants(int[,] solvedBoard)
        {
            TestValuesAreUniqueInNonstant(solvedBoard, 0, 0);
            TestValuesAreUniqueInNonstant(solvedBoard, 1, 0);
            TestValuesAreUniqueInNonstant(solvedBoard, 2, 0);
            TestValuesAreUniqueInNonstant(solvedBoard, 0, 1);
            TestValuesAreUniqueInNonstant(solvedBoard, 1, 1);
            TestValuesAreUniqueInNonstant(solvedBoard, 2, 1);
            TestValuesAreUniqueInNonstant(solvedBoard, 0, 2);
            TestValuesAreUniqueInNonstant(solvedBoard, 1, 2);
            TestValuesAreUniqueInNonstant(solvedBoard, 2, 2);
        }

        private static void TestValuesAreUniqueInNonstant(int[,] solvedBoard, int xOffset, int yOffset)
        {
            List<int> nonstantValues = new List<int>();
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    // a cell's value has not occurend before in the column
                    int newValue = solvedBoard[x + (xOffset * 3), y + (yOffset * 3)];
                    Assert.IsFalse(nonstantValues.Contains(newValue), "Found duplicate cell value " + newValue + " in nonstant");
                    nonstantValues.Add(newValue);
                }
            }
        }
    }
}
