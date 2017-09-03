namespace _04.Array_Lab
{
    using System;
    using System.Linq;

    internal class Lab
    {
        private static void Main()
        {
            // Task 1
            SumArrayElements();

            // Task 2
            MultiplyArrayOfDoubles();

            // Task 3
            SmallestElementInArray();

            // Task 4
            RotateArrayOfStrings();

            // Task 5
            CountOfOddNumbersInArray();

            // Task 6
            OddNumbersAtOddPosition();
        }

        private static void SumArrayElements()
        {
            int number = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < number; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                sum += currentNumber;
            }

            Console.WriteLine(sum);
        }

        private static void MultiplyArrayOfDoubles()
        {
            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double number = double.Parse(Console.ReadLine());

            numbers = numbers.Select(num => num * number).ToArray();
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void SmallestElementInArray()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int smallestNumber = numbers.Min();

            Console.WriteLine(smallestNumber);
        }

        private static void RotateArrayOfStrings()
        {
            string[] input = Console.ReadLine().Split(' ');

            string[] rotatedInput = new string[input.Length];
            rotatedInput[0] = input.Last();

            for (int i = 0; i < input.Length - 1; i++)
            {
                rotatedInput[i + 1] = input[i];
            }

            Console.WriteLine(string.Join(" ", rotatedInput));
        }

        private static void CountOfOddNumbersInArray()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int counter = 0;

            foreach (int number in numbers)
            {
                if (number % 2 == 1 || number % 2 == -1)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }

        private static void OddNumbersAtOddPosition()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];

                if (i % 2 == 1 && (number % 2 == 1 || number % 2 == -1))
                {
                    Console.WriteLine($"Index {i} -> {number}");
                }
            }
        }
    }
}