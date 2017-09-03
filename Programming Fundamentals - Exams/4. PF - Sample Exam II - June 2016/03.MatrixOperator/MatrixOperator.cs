namespace _03.MatrixOperator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class MatrixOperator
    {
        private static void Main()
        {
            // There is a better solution with "List<List<int>>" instead of List<int[]> because the int[] cannot be changed directly;

            // Besides the entire "Remove Row" method can be substituted by LINQ queries:
            // positive - rows[index] = rows[index].Where(x => x < 0).ToList();
            // negative - rows[index] = rows[index].Where(x => x >= 0).ToList();
            // odd - rows[index] = rows[index].Where(x => x % 2 == 0).ToList();
            // even - rows[index] = rows[index].Where(x => x % 2 != 0).ToList();

            // For "Remove Col" method we have to make a "for" loop for all the lines in order to check if they have a column/position
            // with the given index and if the condition is true we can execute the removal - "rows[currentRow].RemoveAt(index);"

            int allRows = int.Parse(Console.ReadLine());
            List<int[]> rows = new List<int[]>();

            for (int row = 0; row < allRows; row++)
            {
                int[] currentRowColumns = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                rows.Add(currentRowColumns);
            }

            string input = Console.ReadLine();
            while (input != null && input.ToLower() != "end")
            {
                string[] tokens = input.Split(' ');
                string command = tokens[0];

                switch (command)
                {
                    case "remove":
                        #region
                        string type = tokens[1];
                        string rowOrColumn = tokens[2];
                        int index = int.Parse(tokens[3]);
                        List<int> currentRowAfter = new List<int>();

                        switch (type)
                        {
                            case "positive":
                                switch (rowOrColumn)
                                {
                                    case "row":
                                        foreach (int number in rows[index])
                                        {
                                            if (number >= 0)
                                            {
                                                continue;
                                            }

                                            currentRowAfter.Add(number);
                                        }

                                        rows[index] = currentRowAfter.ToArray();
                                        break;

                                    case "col":
                                        for (int row = 0; row < rows.Count; row++)
                                        {
                                            currentRowAfter = new List<int>();
                                            if (rows[row].Length > index)
                                            {
                                                for (int numberIndexInRow = 0; numberIndexInRow < rows[row].Length; numberIndexInRow++)
                                                {
                                                    if (numberIndexInRow == index && rows[row][index] >= 0)
                                                    {
                                                        continue;
                                                    }

                                                    currentRowAfter.Add(rows[row][numberIndexInRow]);
                                                }

                                                rows[row] = currentRowAfter.ToArray();
                                            }
                                        }
                                        break;
                                }
                                break;

                            case "negative":
                                switch (rowOrColumn)
                                {
                                    case "row":
                                        currentRowAfter = new List<int>();
                                        foreach (int number in rows[index])
                                        {
                                            if (number < 0)
                                            {
                                                continue;
                                            }

                                            currentRowAfter.Add(number);
                                        }

                                        rows[index] = currentRowAfter.ToArray();
                                        break;

                                    case "col":
                                        for (int row = 0; row < rows.Count; row++)
                                        {
                                            currentRowAfter = new List<int>();
                                            if (rows[row].Length > index)
                                            {
                                                for (int numberIndexInRow = 0; numberIndexInRow < rows[row].Length; numberIndexInRow++)
                                                {
                                                    if (numberIndexInRow == index && rows[row][index] < 0)
                                                    {
                                                        continue;
                                                    }

                                                    currentRowAfter.Add(rows[row][numberIndexInRow]);
                                                }

                                                rows[row] = currentRowAfter.ToArray();
                                            }
                                        }
                                        break;
                                }
                                break;

                            case "even":
                                switch (rowOrColumn)
                                {
                                    case "row":
                                        currentRowAfter = new List<int>();
                                        foreach (int number in rows[index])
                                        {
                                            if (Math.Abs(number) % 2 == 0)
                                            {
                                                continue;
                                            }

                                            currentRowAfter.Add(number);
                                        }

                                        rows[index] = currentRowAfter.ToArray();
                                        break;

                                    case "col":
                                        for (int row = 0; row < rows.Count; row++)
                                        {
                                            currentRowAfter = new List<int>();
                                            if (rows[row].Length > index)
                                            {
                                                for (int numberIndexInRow = 0; numberIndexInRow < rows[row].Length; numberIndexInRow++)
                                                {
                                                    if (numberIndexInRow == index && Math.Abs(rows[row][index]) % 2 == 0)
                                                    {
                                                        continue;
                                                    }

                                                    currentRowAfter.Add(rows[row][numberIndexInRow]);
                                                }

                                                rows[row] = currentRowAfter.ToArray();
                                            }
                                        }
                                        break;
                                }
                                break;

                            case "odd":
                                switch (rowOrColumn)
                                {
                                    case "row":
                                        currentRowAfter = new List<int>();
                                        foreach (int number in rows[index])
                                        {
                                            if (Math.Abs(number) % 2 == 1)
                                            {
                                                continue;
                                            }

                                            currentRowAfter.Add(number);
                                        }

                                        rows[index] = currentRowAfter.ToArray();
                                        break;

                                    case "col":
                                        for (int row = 0; row < rows.Count; row++)
                                        {
                                            currentRowAfter = new List<int>();
                                            if (rows[row].Length > index)
                                            {
                                                for (int numberIndexInRow = 0; numberIndexInRow < rows[row].Length; numberIndexInRow++)
                                                {
                                                    if (numberIndexInRow == index && Math.Abs(rows[row][index]) % 2 == 1)
                                                    {
                                                        continue;
                                                    }

                                                    currentRowAfter.Add(rows[row][numberIndexInRow]);
                                                }

                                                rows[row] = currentRowAfter.ToArray();
                                            }
                                        }
                                        break;
                                }
                                break;
                        }
                        break;
                    #endregion

                    case "insert":
                        #region
                        int rowIndex = int.Parse(tokens[1]);
                        int numberToInsert = int.Parse(tokens[2]);
                        currentRowAfter = new List<int>
                        {
                            numberToInsert
                        };

                        currentRowAfter.AddRange(rows[rowIndex]);
                        rows[rowIndex] = currentRowAfter.ToArray();
                        break;
                    #endregion

                    case "swap":
                        int firstRowIndex = int.Parse(tokens[1]);
                        int secondRowIndex = int.Parse(tokens[2]);
                        currentRowAfter = new List<int>();

                        currentRowAfter.AddRange(rows[firstRowIndex]);
                        rows[firstRowIndex] = rows[secondRowIndex];
                        rows[secondRowIndex] = currentRowAfter.ToArray();
                        break;
                }

                input = Console.ReadLine();
            }

            for (int row = 0; row < allRows; row++)
            {
                Console.WriteLine(string.Join(" ", rows[row]));
            }
        }
    }
}