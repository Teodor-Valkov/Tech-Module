namespace _01.DataTypes_Second_Lab
{
    using System;

    class Lab
    {
        static void Main()
        {
            // Task 1
            SpecialNumbers();

            // Task 2
            TriplesOfLetters();

            // Task 3
            Greeting();

            // Task 4
            RefactorVolumeOfPiramid();

            // Task 5
            RefactorSpecialNumbers();
        }

        private static void SpecialNumbers()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int currentNumber = i;
                int sum = SumOfDigits(currentNumber);
                bool equal = sum == 5 || sum == 7 || sum == 11;

                Console.WriteLine($"{i} -> {equal}");
            }
        }

        public static int SumOfDigits(int currentNumber)
        {
            int sum = 0;

            while (currentNumber != 0)
            {
                sum += currentNumber % 10;
                currentNumber /= 10;
            }

            return sum;
        }

        private static void TriplesOfLetters()
        {
            int n = int.Parse(Console.ReadLine());

            for (char i = 'a'; i < 'a' + n; i++)
            {
                for (char j = 'a'; j < 'a' + n; j++)
                {
                    for (char k = 'a'; k < 'a' + n; k++)
                    {
                        Console.WriteLine($"{i}{j}{k}");
                    }
                }
            }
        }

        private static void Greeting()
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine($"Hello, {firstName} {lastName}. You are {age} years old.");
        }

        private static void RefactorVolumeOfPiramid()
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double volume = (length * width * height) / 3;
            Console.WriteLine($"Length: Width: Height: Pyramid Volume: {volume:F2}");
        }

        private static void RefactorSpecialNumbers()
        {
            int numbers = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= numbers; i++)
            {
                int currentNumber = i;

                while (currentNumber > 0)
                {
                    sum += currentNumber % 10;
                    currentNumber = currentNumber / 10;
                }

                bool answer = (sum == 5) || (sum == 7) || (sum == 11);

                sum = 0;

                Console.WriteLine($"{i} -> {answer}");
            }
        }
    }
}
