namespace _05.BlurFilter
{
    using System;
    using System.Linq;

    class BlurFilter
    {
        static void Main()
        {
            decimal blurAmount = decimal.Parse(Console.ReadLine());
            int[] rowsAndCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            decimal[,] matrix = new decimal[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                decimal[] cells = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = cells[col];   
                }
            }
            
            int[] target = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int targetRow = target[0];
            int targetCol = target[1];

            int startRow = Math.Max(0, targetRow - 1);
            int endRow = Math.Min(rows - 1, targetRow + 1);
            int startCol = Math.Max(0, targetCol - 1);
            int endCol = Math.Min(cols - 1, targetCol + 1);

            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    matrix[row, col] += blurAmount;
                }
            }
            
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
