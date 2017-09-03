namespace _07.MaxSequenceOfIncreasingElements
{
    using System;
    using System.Linq;

    internal class MaxSequenceOfIncreasingElements
    {
        private static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int start = 0;
            int length = 0;
            int bestStart = 0;
            int bestLength = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] - numbers[i - 1] > 0)
                {
                    length++;
                    start = i - length;

                    if (length > bestLength)
                    {
                        bestLength = length;
                        bestStart = start;
                    }
                }
                else
                {
                    length = 0;
                }
            }

            for (int i = bestStart; i <= bestStart + bestLength; i++)
            {
                if (i == bestStart + bestLength)
                {
                    Console.WriteLine(numbers[i]);
                }
                else
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
    }
}