namespace _13.LongestIncreasingSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class LongestIncreasingSubsequence
    {
        public static void Main()
        {
            List<int> sequence = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> longestIncreasingSubsequence = FindLongestIncreasingSubsequence(sequence);

            Console.WriteLine(string.Join(" ", longestIncreasingSubsequence));
        }

        private static List<int> FindLongestIncreasingSubsequence(List<int> sequence)
        {
            int[] numbers = new int[sequence.Count];
            int[] previous = new int[sequence.Count];

            int maxLength = 0;
            int lastIndex = -1;

            for (int i = 0; i < sequence.Count; i++)
            {
                numbers[i] = 1;
                previous[i] = -1;

                for (int j = 0; j < i; j++)
                {
                    if (sequence[j] < sequence[i] && numbers[j] + 1 > numbers[i])
                    {
                        numbers[i] = numbers[j] + 1;
                        previous[i] = j;
                    }
                }

                if (numbers[i] > maxLength)
                {
                    maxLength = numbers[i];
                    lastIndex = i;
                }
            }

            List<int> list = new List<int>();

            while (lastIndex != -1)
            {
                list.Add(sequence[lastIndex]);
                lastIndex = previous[lastIndex];
            }

            list.Reverse();

            return list;
        }
    }
}