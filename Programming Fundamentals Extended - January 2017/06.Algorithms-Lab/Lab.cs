namespace _06.Algorithms_Lab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Lab
    {
        private static void Main()
        {
            // Task 1
            ArrayContainsElement();

            // Task 2
            SmallestElementInArray();

            // Task 3
            ReverseArrayInPlace();

            // Task 4
            SortArrayUsingBubbleSort();

            // Task 5
            SortArrayUsingInsertionSort();

            // Task 6
            InsertionSortUsingList();

            // Task 7
            LargestCountOfElements();
        }

        private static void ArrayContainsElement()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(numbers.Contains(number) ? "yes" : "no");
        }

        private static void SmallestElementInArray()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            Console.WriteLine(numbers.Min());
        }

        private static void ReverseArrayInPlace()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            numbers.Reverse();

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void SortArrayUsingBubbleSort()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int temp = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        temp = numbers[j + 1];
                        numbers[j + 1] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void SortArrayUsingInsertionSort()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 1; i < numbers.Length; i++)
            {
                int temp = numbers[i];
                bool stop = false;

                for (int j = i - 1; j >= 0 && stop == false;)
                {
                    if (temp < numbers[j])
                    {
                        numbers[j + 1] = numbers[j];
                        j--;
                        numbers[j + 1] = temp;
                    }
                    else
                    {
                        stop = true;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void InsertionSortUsingList()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 1; i < numbers.Count; i++)
            {
                int temp = numbers[i];
                bool stop = false;

                for (int j = i - 1; j >= 0 && stop == false;)
                {
                    if (temp < numbers[j])
                    {
                        numbers[j + 1] = numbers[j];
                        j--;
                        numbers[j + 1] = temp;
                    }
                    else
                    {
                        stop = true;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void LargestCountOfElements()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(" ", numbers.OrderByDescending(num => num).Take(number)));
        }
    }
}