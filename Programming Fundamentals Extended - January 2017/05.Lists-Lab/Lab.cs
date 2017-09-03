namespace _05.Lists_Lab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Lab
    {
        private static void Main()
        {
            // Task 1
            RemoveNegativesAndReverse();

            // Task 2
            AppendLists();

            // Task 3
            SumAdjacentEqualNumbers();

            // Task 4
            SplitByWordCasing();

            // Task 5
            SortNumbers();

            // Task 6
            SquareNumbers();

            // Task 7
            CountNumbers();
        }

        private static void RemoveNegativesAndReverse()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("empty");
            }

            numbers.Reverse();

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void AppendLists()
        {
            List<string> manyLists = Console.ReadLine().Split('|').ToList();
            List<string> answerLists = new List<string>();

            for (int i = manyLists.Count - 1; i >= 0; i--)
            {
                string[] currentList = manyLists[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string letter in currentList)
                {
                    if (letter != "")
                    {
                        answerLists.Add(letter);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", answerLists));
        }

        private static void SumAdjacentEqualNumbers()
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

        private static void SplitByWordCasing()
        {
            string separators = ",;:.!()\'\"/\\[] ";
            string[] input = Console.ReadLine().Split(separators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            List<string> lowerCaseList = new List<string>();
            List<string> mixedCaseList = new List<string>();
            List<string> upperCaseList = new List<string>();

            foreach (string word in input)
            {
                int lowerLetters = 0;
                int upperLetters = 0;

                foreach (char letter in word)
                {
                    if (char.IsLower(letter))
                    {
                        lowerLetters++;
                    }

                    if (char.IsUpper(letter))
                    {
                        upperLetters++;
                    }
                }

                if (lowerLetters == word.Length)
                {
                    lowerCaseList.Add(word);
                }
                else if (upperLetters == word.Length)
                {
                    upperCaseList.Add(word);
                }
                else
                {
                    mixedCaseList.Add(word);
                }
            }

            Console.WriteLine("Lower-case: " + string.Join(", ", lowerCaseList));
            Console.WriteLine("Mixed-case: " + string.Join(", ", mixedCaseList));
            Console.WriteLine("Upper-case: " + string.Join(", ", upperCaseList));
        }

        private static void SortNumbers()
        {
            List<decimal> numbers = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();
            numbers.Sort();

            Console.WriteLine(string.Join(" <= ", numbers));
        }

        private static void SquareNumbers()
        {
            List<double> numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            List<double> result = new List<double>();

            foreach (double number in numbers)
            {
                if (number % Math.Sqrt(number) == 0)
                //or (Math.Sqrt(numbers[i] == (int)Math.Sqrt(numbers[i]))
                {
                    result.Add(number);
                }
            }

            result.Sort((a, b) => b.CompareTo(a));
            //or .Sort() and .Reverse();

            Console.WriteLine(string.Join(" ", result));
        }

        private static void CountNumbers()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> numsDistinct = numbers.Distinct().OrderBy(x => x).ToList();
            List<int> occurrences = new List<int>();

            foreach (int num in numsDistinct)
            {
                occurrences.Add(numbers.Count(x => x == num));
            }

            for (int i = 0; i < occurrences.Count; i++)
            {
                Console.WriteLine($"{numsDistinct[i]} -> {occurrences[i]}");
            }
        }
    }
}