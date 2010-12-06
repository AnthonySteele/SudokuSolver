namespace Tests
{
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
        }
    }
}
