namespace _02.RotateAndSum
{
    using System;
    using System.Linq;

    class RotateAndSum
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            long[] sums = new long[numbers.Length];

            for (int rotation = 0; rotation < rotations; rotation++)
            {
                int[] currentNumbers = new int[numbers.Length];

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (i == 0)
                    {
                        currentNumbers[i] = numbers.Last();
                    }
                    else
                    {
                        currentNumbers[i] = numbers[i - 1];
                    }

                    sums[i] += currentNumbers[i];
                }

                numbers = currentNumbers;
            }

            Console.WriteLine(string.Join(" ", sums));
        }
    }
}
