namespace _03.Portal
{
    using System;
    using System.Collections.Generic;

    class Portal
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int turns = 0;
            int currentRow = 0;
            int currentCol = 0;
            bool success = false;

            List<string> matrix = new List<string>();
            for (int i = 0; i < n; i++)
            {
                matrix.Add(Console.ReadLine());
                if (matrix[i].Contains("S"))
                {
                    currentRow = i;
                    currentCol = matrix[i].IndexOf("S", StringComparison.Ordinal);
                }
            }

            string input = Console.ReadLine();
            if (input != null)
            {
                foreach (char symbol in input)
                {
                    turns++;
                    switch (symbol)
                    {
                        case 'D':
                            while (true)
                            {
                                currentRow++;
                                if (currentRow == matrix.Count)
                                {
                                    currentRow = 0;
                                    if (currentCol >= matrix[currentRow].Length)
                                    {
                                        continue;
                                    }
                                    break;
                                }

                                if (currentCol >= matrix[currentRow].Length)
                                {
                                    continue;
                                }
                                break;
                            }
                            break;

                        case 'U':
                            while (true)
                            {
                                currentRow--;
                                if (currentRow == -1)
                                {
                                    currentRow = matrix.Count - 1;
                                    if (currentCol >= matrix[currentRow].Length)
                                    {
                                        continue;
                                    }
                                    break;
                                }
                                if (currentCol >= matrix[currentRow].Length)
                                {
                                    continue;
                                }
                                break;
                            }
                            break;

                        case 'L':
                            currentCol--;
                            if (currentCol == -1)
                            {
                                currentCol = matrix[currentRow].Length - 1;
                            }
                            break;

                        case 'R':
                            currentCol++;
                            if (currentCol == matrix[currentRow].Length)
                            {
                                currentCol = 0;
                            }
                            break;
                    }

                    if (matrix[currentRow][currentCol] == 'E')
                    {
                        Console.WriteLine($"Experiment successful. {turns} turns required.");
                        success = true;
                        break;
                    }
                }
            }

            if (!success)
            {
                Console.WriteLine($"Robot stuck at {currentRow} {currentCol}. Experiment failed.");           
            }
        }
    }
}
