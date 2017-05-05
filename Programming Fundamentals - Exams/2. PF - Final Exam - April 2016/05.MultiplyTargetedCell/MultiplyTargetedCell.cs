namespace _05.MultiplyTargetedCell
{
    using System;
    using System.Linq;

    class MultiplyTargetedCell
    {
        static void Main()
        {
            int[] rowsAndCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];
            long[,] matrix = new long[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                long[] cells = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = cells[col];
                }
            }

            int[] targetCell = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int targetRow = targetCell[0];
            int targetCol = targetCell[1];

            long targetCellNewValue = 0;
            long targetCellOldvalue = matrix[targetRow, targetCol];

            targetCellNewValue += matrix[targetRow - 1, targetCol - 1];
            targetCellNewValue += matrix[targetRow - 1, targetCol];
            targetCellNewValue += matrix[targetRow - 1, targetCol + 1];
            targetCellNewValue += matrix[targetRow, targetCol - 1];
            targetCellNewValue += matrix[targetRow, targetCol + 1];
            targetCellNewValue += matrix[targetRow + 1, targetCol - 1];
            targetCellNewValue += matrix[targetRow + 1, targetCol];
            targetCellNewValue += matrix[targetRow + 1, targetCol + 1];

            matrix[targetRow, targetCol] *= targetCellNewValue;

            matrix[targetRow - 1, targetCol - 1] *= targetCellOldvalue;
            matrix[targetRow - 1, targetCol] *= targetCellOldvalue;
            matrix[targetRow - 1, targetCol + 1] *= targetCellOldvalue;
            matrix[targetRow, targetCol - 1] *= targetCellOldvalue;
            matrix[targetRow, targetCol + 1] *= targetCellOldvalue;
            matrix[targetRow + 1, targetCol - 1] *= targetCellOldvalue;
            matrix[targetRow + 1, targetCol] *= targetCellOldvalue;
            matrix[targetRow + 1, targetCol + 1] *= targetCellOldvalue;

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
