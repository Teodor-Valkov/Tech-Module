namespace _04.TrifonsQuest
{
    using System;

    internal class TrifonsQuest
    {
        private static void Main()
        {
            long health = long.Parse(Console.ReadLine());
            string[] typeRowsAndCols = Console.ReadLine().Split(' ');

            int rows = int.Parse(typeRowsAndCols[0]);
            int cols = int.Parse(typeRowsAndCols[1]);
            char[,] matrix = new char[rows, cols];

            long turns = 0;
            int direction = 1;
            int currentRow = 0;

            FillingTheMatrixCells(rows, cols, matrix);

            for (int col = 0; col < cols; col++)
            {
                if (direction == 1)
                {
                    for (currentRow = 0; currentRow < rows; currentRow++)
                    {
                        char currentCell = matrix[currentRow, col];

                        switch (currentCell)
                        {
                            case 'F': health -= (turns / 2); break;
                            case 'H': health += (turns / 3); break;
                            case 'T': turns += 2; break;
                        }

                        turns++;

                        if (health <= 0)
                        {
                            Console.WriteLine($"Died at: [{currentRow}, {col}]");
                            return;
                        }

                        if (currentRow == rows - 1)
                        {
                            direction = -1;
                        }
                    }
                }
                else if (direction == -1)
                {
                    for (currentRow = rows - 1; currentRow >= 0; currentRow--)
                    {
                        char currentCell = matrix[currentRow, col];

                        switch (currentCell)
                        {
                            case 'F': health -= (turns / 2); break;
                            case 'H': health += (turns / 3); break;
                            case 'T': turns += 2; break;
                        }

                        turns++;

                        if (health <= 0)
                        {
                            Console.WriteLine($"Died at: [{currentRow}, {col}]");
                            return;
                        }

                        if (currentRow == 0)
                        {
                            direction = 1;
                        }
                    }
                }
            }

            QuestCompletedPrinting(health, turns);
        }

        private static void QuestCompletedPrinting(long health, long turns)
        {
            if (health > 0)
            {
                Console.WriteLine("Quest completed!");
                Console.WriteLine($"Health: {health}");
                Console.WriteLine($"Turns: {turns}");
            }
        }

        private static void FillingTheMatrixCells(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                string cells = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = cells[col];
                }
            }
        }
    }
}