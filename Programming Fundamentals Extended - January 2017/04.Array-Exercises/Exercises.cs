namespace _04.Array_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Exercises
    {
        private static void Main()
        {
            // Task 1
            LargestElementInArray();

            // Task 2
            CountNegativeElementsInArray();

            // Task 3
            CountGivenElementInArray();

            // Task 4
            CountOccurrencesOfLargerNumbersInArray();

            // Task 5
            IncreasingSequenceOfElements();

            // Task 6
            EqualSequenceOfElementsInArray();

            // Task 7
            CountCapitalLettersInArray();

            // Task 8
            ArraySymmetry();

            // Task 9
            Altitude();

            // Task 10
            BallisticsTraining();
        }

        private static void LargestElementInArray()
        {
            int number = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();

            for (int i = 0; i < number; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine(numbers.Max());
        }

        private static void CountNegativeElementsInArray()
        {
            int number = int.Parse(Console.ReadLine());
            List<int> negativeNumbers = new List<int>();

            for (int i = 0; i < number; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber < 0)
                {
                    negativeNumbers.Add(currentNumber);
                }
            }

            Console.WriteLine(negativeNumbers.Count);
        }

        private static void CountGivenElementInArray()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(numbers.Count(num => num == number));
        }

        private static void CountOccurrencesOfLargerNumbersInArray()
        {
            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double number = double.Parse(Console.ReadLine());

            Console.WriteLine(numbers.Count(num => num > number));
        }

        private static void IncreasingSequenceOfElements()
        {
            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            bool isAnIncreasingSubsequence = true;

            for (int i = 1; i < numbers.Length; i++)
            {
                double previuosNumber = numbers[i - 1];
                double currentNumber = numbers[i];

                if (currentNumber > previuosNumber)
                {
                    continue;
                }

                isAnIncreasingSubsequence = false;
                break;
            }

            Console.WriteLine(isAnIncreasingSubsequence ? "Yes" : "No");
        }

        private static void EqualSequenceOfElementsInArray()
        {
            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            bool isAnIncreasingSubsequence = true;

            for (int i = 1; i < numbers.Length; i++)
            {
                double previuosNumber = numbers[i - 1];
                double currentNumber = numbers[i];

                if (currentNumber == previuosNumber)
                {
                    continue;
                }

                isAnIncreasingSubsequence = false;
                break;
            }

            Console.WriteLine(isAnIncreasingSubsequence ? "Yes" : "No");
        }

        private static void CountCapitalLettersInArray()
        {
            string[] inputArgs = Console.ReadLine().Split();
            int count = 0;

            foreach (string arg in inputArgs)
            {
                if (arg != null && arg.All(char.IsUpper))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        private static void ArraySymmetry()
        {
            string[] inputArgs = Console.ReadLine().Split();
            bool isSimmetric = true;

            for (int i = 0; i < inputArgs.Length / 2; i++)
            {
                if (inputArgs[i] == inputArgs[inputArgs.Length - i - 1])
                {
                    continue;
                }

                isSimmetric = false;
                break;
            }

            Console.WriteLine(isSimmetric ? "Yes" : "No");
        }

        private static void Altitude()
        {
            string[] inputArgs = Console.ReadLine().Split();
            double initialAltitude = double.Parse(inputArgs[0]);

            for (int i = 1; i < inputArgs.Length; i += 2)
            {
                string direction = inputArgs[i];
                double altitude = double.Parse(inputArgs[i + 1]);

                switch (direction)
                {
                    case "up": initialAltitude += altitude; break;
                    case "down": initialAltitude -= altitude; break;
                }

                if (initialAltitude <= 0)
                {
                    Console.WriteLine("crashed");
                    return;
                }
            }

            Console.WriteLine($"got through safely. current altitude: {initialAltitude}m");
        }

        private static void BallisticsTraining()
        {
            int[] airplanePosition = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int airplaneX = airplanePosition[0];
            int airplaneY = airplanePosition[1];

            string[] inputArgs = Console.ReadLine().Split();
            int pointX = 0;
            int pointY = 0;

            for (int i = 0; i < inputArgs.Length; i++)
            {
                string direction = inputArgs[i];

                switch (direction)
                {
                    case "up": pointY += int.Parse(inputArgs[i + 1]); break;
                    case "down": pointY -= int.Parse(inputArgs[i + 1]); break;
                    case "left": pointX -= int.Parse(inputArgs[i + 1]); break;
                    case "right": pointX += int.Parse(inputArgs[i + 1]); break;
                }
            }

            if (airplaneX == pointX && airplaneY == pointY)
            {
                Console.WriteLine($"firing at [{pointX}, {pointY}]\ngot 'em!");
            }
            else
            {
                Console.WriteLine($"firing at [{pointX}, {pointY}]\nbetter luck next time...");
            }
        }
    }
}