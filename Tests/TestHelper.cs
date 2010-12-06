namespace Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    public static class TestHelper
    {
        public static void TestSolutionValid(int[,] solvedBoard)
        {
            foreach (int value in solvedBoard)
            {
                Assert.Greater(value, 0);
                Assert.Less(value, 10);
            }

            TestValuesAreUniqueInColumn(solvedBoard);
            TestvaluesAreUniqueInRow(solvedBoard);
        }

        private static void TestvaluesAreUniqueInRow(int[,] solvedBoard)
        {
            for (int y = 0; y < 9; y++)
            {
                List<int> rowValues = new List<int>();
                for (int x = 0; x < 9; x++)
                {
                    // a cell's value has not occurend before in the row
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
                    // a cell's value has not occurend before in the column
                    int newValue = solvedBoard[x, y];
                    Assert.IsFalse(columnValues.Contains(newValue), "Found duplicate cell value " + newValue + " in column");
                    columnValues.Add(newValue);
                }
            }
        }
    }
}
