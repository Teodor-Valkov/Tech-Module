namespace _05.Lists_Exercises
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Exercises
    {
        static void Main()
        {
            // Task 1
            RemoveElementsAtOddPositions();

            // Task 2
            TrackDownloader();

            // Task 3
            EqualSumAfterExtraction();

            // Task 4
            FlipListSides();

            // Task 5
            TearListInHalf();

            // Task 6
            StuckZipper();
        }

        private static void RemoveElementsAtOddPositions()
        {
            List<string> inputList = Console.ReadLine().Split().ToList();
            List<string> resultList = new List<string>();

            for (int i = 1; i < inputList.Count; i+=2)
            {
                resultList.Add(inputList[i]);
            }

            Console.WriteLine(string.Join("", resultList));
        }

        private static void TrackDownloader()
        {
            string[] forbiddenWords = Console.ReadLine().Split();
            List<string> resultList = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();
                bool isValid = true;

                if (input == null || input == "end")
                    break;

                foreach (string word in forbiddenWords)
                {
                    if (input.Contains(word))
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    resultList.Add(input);                
                }
            }

            resultList.Sort();
            Console.WriteLine(string.Join("\n", resultList));
        }

        private static void EqualSumAfterExtraction()
        {
            List<int> firstNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> secondNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 0; i < secondNumbers.Count; i++)
            {
                if (firstNumbers.Contains(secondNumbers[i]))
                {
                    secondNumbers.Remove(secondNumbers[i]);
                    i--;
                }
            }

            string result = firstNumbers.Sum() == secondNumbers.Sum()
                ? $"Yes. Sum: {firstNumbers.Sum()}"
                : $"No. Diff: {Math.Abs(firstNumbers.Sum() - secondNumbers.Sum())}";
            
            Console.WriteLine(result);
            
        }

        private static void FlipListSides()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 1; i < numbers.Count / 2; i++)
            {
                int tempNumber = numbers[i];
                numbers[i] = numbers[numbers.Count - i - 1];
                numbers[numbers.Count - i - 1] = tempNumber;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void TearListInHalf()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> tempNumbers = numbers.Skip(numbers.Count/2).Take(numbers.Count).ToList();
            numbers.RemoveRange(numbers.Count / 2, numbers.Count / 2);

            List<int> result = new List<int>();

            for (int i = 0; i < tempNumbers.Count; i++)
            {
                int firstDigit = tempNumbers[i] / 10;
                int secondDigit = tempNumbers[i] % 10;

                result.Add(firstDigit);
                result.Add(numbers[i]);
                result.Add(secondDigit);
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static void StuckZipper()
        {
            List<int> firstNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> secondNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> result = new List<int>();

            int smallestNumber = Math.Min(firstNumbers.Min(), secondNumbers.Min());
            int smallestNumberLength = smallestNumber.ToString().Length;

            if (smallestNumber < 0)
            {
                smallestNumberLength--;
            }

            firstNumbers.RemoveAll(number => Math.Abs(number).ToString().Length != smallestNumberLength);
            secondNumbers.RemoveAll(number => Math.Abs(number).ToString().Length != smallestNumberLength);

            int smallerListCount = Math.Min(firstNumbers.Count, secondNumbers.Count);

            for (int i = 0; i < smallerListCount; i++)
            {
                result.Add(secondNumbers[i]);
                result.Add(firstNumbers[i]);
            }

            if (firstNumbers.Count != smallerListCount)
            {
                result.AddRange(firstNumbers.Skip(smallerListCount).Take(firstNumbers.Count));
            }

            if (secondNumbers.Count != smallerListCount)
            {
                result.AddRange(secondNumbers.Skip(smallerListCount).Take(secondNumbers.Count));
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
