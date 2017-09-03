namespace _09.Lambda_LINQ_Lab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Lab
    {
        private static void Main()
        {
            // Task 1
            SumMinMaxAverage();

            // Task 2
            LargestThreeNumbers();

            // Task 3
            ShortWordsSorted();

            // Task 4
            FoldAndSum();
        }

        private static void SumMinMaxAverage()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Sum = {numbers.Sum()}");
            Console.WriteLine($"Min = {numbers.Min()}");
            Console.WriteLine($"Max = {numbers.Max()}");
            Console.WriteLine($"Average = {numbers.Average()}");
        }

        private static void LargestThreeNumbers()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> sortedReversedNumbers = numbers.OrderBy(x => -x).ToList();
            // or Sort() and Reverse();
            // or OrderByDescending();

            List<int> largestThree = sortedReversedNumbers.Take(3).ToList();

            Console.WriteLine(string.Join(", ", largestThree));
        }

        private static void ShortWordsSorted()
        {
            string separators = ".,:;()[]\"'\\/!? ";

            List<string> input = Console.ReadLine().ToLower().Split(separators.ToCharArray()).ToList();

            input = input.Where(x => x.Length > 0 && x.Length < 5)
                     .Distinct()
                     .OrderBy(x => x)
                     .ToList();

            Console.WriteLine(string.Join(", ", input));
        }

        private static void FoldAndSum()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int part = numbers.Length / 4;

            int[] firstPart = numbers.Take(part).Reverse().ToArray();
            int[] middlePart = numbers.Skip(part).Take(part * 2).ToArray();
            int[] thirdPart = numbers.Reverse().Take(part).ToArray();

            int[] firstRow = firstPart.Concat(thirdPart).ToArray();
            int[] secondRow = middlePart;

            int[] sumNumbersOfTheRows = firstRow.Select((x, index) => x + secondRow[index]).ToArray();

            //int[] sumNumbersOfTheRows = new int[firstRow.Length];
            //for (int i = 0; i < firstRow.Length; i++)
            //{
            //    sumNumbersOfTheRows[i] = firstRow[i] + secondRow[i];
            //}

            Console.WriteLine(string.Join(" ", sumNumbersOfTheRows));
        }
    }
}