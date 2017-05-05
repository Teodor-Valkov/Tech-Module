namespace _03.TargetMultiplier
{
    using System;
    using System.Linq;

    class TargetMultiplier
    {
        static void Main()
        {
            int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] cells = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = cells[col];
                }
            }

            int[] targetCell = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int targetRow = targetCell[0];
            int targetCol = targetCell[1];

            int startRow = targetRow - 1;
            int endRow = targetRow + 1;
            int startCol = targetCol - 1;
            int endCol = targetCol + 1;

            int sumOfNeighbourCells = 0;
            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    if (row == targetRow && col == targetCol)
                    {
                        continue;
                    }

                    sumOfNeighbourCells += matrix[row, col];
                }
            }

            int oldValueTargetCell = matrix[targetRow, targetCol];
            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    if (row == targetRow && col == targetCol)
                    {
                        matrix[row, col] = oldValueTargetCell*sumOfNeighbourCells;
                    }
                    else
                    {
                        matrix[row, col] *= oldValueTargetCell;
                    }
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
