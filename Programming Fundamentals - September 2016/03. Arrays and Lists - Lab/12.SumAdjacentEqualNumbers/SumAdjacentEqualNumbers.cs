namespace _12.SumAdjacentEqualNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class SumAdjacentEqualNumbers
    {
        static void Main()
        {
            List<double> numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            for (int i = 1; i < numbers.Count; i++)
            {
                double current = numbers[i];
                double previous = numbers[i - 1];

                if (current == previous)
                {
                    numbers[i - 1] += current;
                    numbers.Remove(numbers[i]);

                    if (i > 1)
                    {
                        i -= 2;
                    }
                    else
                    {
                        i--;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
