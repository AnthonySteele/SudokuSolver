using System.Text;

namespace Sudoku
{
    public static class OutputFormatter
    {
        public static string Format(int[,] data)
        {
            StringBuilder result  = new StringBuilder();

            for (int x = 0; x < data.GetLength(0); x++)
            {
                bool firstItem = true;
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    if (firstItem)
                    {
                        firstItem = false;
                    }
                    else
                    {
                        result.Append(", ");
                    }
                    result.Append(data[x, y]);

                }
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
