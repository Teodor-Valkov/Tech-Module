namespace _16.BePositive
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class BePositive
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Trim().Split(' ');

                List<double> numbers = new List<double>();

                foreach (string str in input)
                {
                    if (!str.Equals(string.Empty))
                    {
                        double num = double.Parse(str);
                        numbers.Add(num);
                    }
                }

                bool found = false;

                for (int j = 0; j < numbers.Count; j++)
                {
                    double currentNum = numbers[j];

                    if (currentNum >= 0)
                    {
                        if (found)
                        {
                            Console.Write(" ");
                        }

                        found = true;

                        Console.Write(currentNum);
                    }
                    else
                    {
                        if (j == numbers.Count() - 1)
                        {
                            break;
                        }

                        currentNum += numbers[j + 1];

                        if (currentNum >= 0)
                        {
                            if (found)
                            {
                                Console.Write(" ");
                            }

                            found = true;
                            j++;

                            Console.Write(currentNum);
                        }
                        else
                        {
                            j++;
                        }
                    }
                }

                if (!found)
                {
                    Console.Write("(empty)");
                }

                Console.WriteLine();
            }
        }
    }
}
