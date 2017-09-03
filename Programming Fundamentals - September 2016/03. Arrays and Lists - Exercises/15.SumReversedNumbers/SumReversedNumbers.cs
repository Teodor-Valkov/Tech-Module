namespace _15.SumReversedNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SumReversedNumbers
    {
        private static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');

            List<long> reversedNumbers = new List<long>();

            foreach (string currentNumber in input)
            {
                string reversedNumber = string.Empty;

                for (int j = currentNumber.Length - 1; j >= 0; j--)
                {
                    reversedNumber += currentNumber[j];
                }

                reversedNumbers.Add(long.Parse(reversedNumber));
            }

            long sum = reversedNumbers.Sum();

            Console.WriteLine(sum);
        }
    }
}