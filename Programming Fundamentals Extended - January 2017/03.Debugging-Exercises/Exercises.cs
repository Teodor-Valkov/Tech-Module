namespace _03.Debugging_Exercises
{
    using System;

    class Exercises
    {
        static void Main()
        {
            // Task 1
            TrickyStrings();

            // Task 2
            TriangleFormation();

            // Task 3
            Tetris();

            // Task 4
            MiningCoins();
        }

        private static void TrickyStrings()
        {
            string delimiter = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            string result = string.Empty;
            string currentString = string.Empty;

            for (int i = 0; i < number; i++)
            {
                currentString = Console.ReadLine();

                if (i == number - 1)
                {
                    result += currentString;
                }
                else
                {
                    result += currentString + delimiter;
                }
            }

            Console.WriteLine(result);
        }

        private static void TriangleFormation()
        {

            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            bool triangleValidityConditionFirst = a + b > c;
            bool triangleValidityConditionSecond = b + c > a;
            bool triangleValidityConditionThird = a + c > b;

            bool isTriangleValid = triangleValidityConditionFirst && triangleValidityConditionSecond && triangleValidityConditionThird;

            if (isTriangleValid)
            {
                Console.WriteLine("Triangle is valid.");
            }
            else
            {
                Console.WriteLine("Invalid Triangle.");
                return;
            }

            bool rightTriangleConditioFirst = a * a + b * b == c * c;
            bool rightTriangleConditionSecond = b * b + c * c == a * a;
            bool rightTriangleConditionThird = a * a + c * c == b * b;
            
            if (rightTriangleConditioFirst || rightTriangleConditionSecond || rightTriangleConditionThird)
            {
                if (c > a && c > b)
                {
                    Console.WriteLine("Triangle has a right angle between sides a and b");
                }
                else if (b > a && b > c)
                {
                    Console.WriteLine("Triangle has a right angle between sides a and c");
                }
                else if (a > b && a > c)
                {
                    Console.WriteLine("Triangle has a right angle between sides b and c");
                }
            }
            else
            {
                Console.WriteLine("Triangle has no right angles");
            }
        }

        private static void Tetris()
        {
            int number = int.Parse(Console.ReadLine());
            string currentDirection = Console.ReadLine();

            while (currentDirection != null && currentDirection.ToLower() != "exit")
            {
                switch (currentDirection)
                {
                    case "up": Up(number); break;
                    case "down": Down(number); break;
                    case "right": Right(number); break;
                    case "left": Left(number); break;
                }

                currentDirection = Console.ReadLine();
            }
        }

        private static void MiningCoins()
        {
            int number = int.Parse(Console.ReadLine());

            string decrypted = "";
            float totalValue = 0;

            for (int i = 0; i < number; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                int digitFirst = currentNumber / 100;
                int digitSecond= currentNumber % 100 / 10;
                int digitThird = currentNumber % 10;

                totalValue += (digitFirst + digitSecond + digitThird) / (float)number;

                string asciiCodeAsString = digitFirst + digitThird.ToString();
                int asciiCode = 0;

                if (i % 2 == 0)
                {
                    asciiCode = int.Parse(asciiCodeAsString) - digitSecond;
                }
                else
                {
                    asciiCode = int.Parse(asciiCodeAsString) + digitSecond;
                }

                if (char.IsLetter((char)asciiCode))
                {
                    decrypted += (char)asciiCode;
                }
            }
            
            Console.WriteLine($"Message: {decrypted}");
            Console.WriteLine($"Value: {totalValue:F7}");
        }

        private static void Up(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('.', n) + new string('*', n) + new string('.', n));
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('*', n * 3));
            }
        }

        private static void Down(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('*', n * 3));
            }
            
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('.', n) + new string('*', n) + new string('.', n));
            }
        }

        private static void Right(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('*', n)+ new string('.', n));
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('*', 2 * n));
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('*', n) + new string('.', n));
            }
        }

        private static void Left(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('.', n) + new string('*', n));
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('*', 2 * n));
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('.', n)+ new string('*', n));
            }
        }
    }
}
