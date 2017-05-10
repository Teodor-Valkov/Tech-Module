namespace _02.Methods_Lab
{
    using System;

    class Lab
    {
        static void Main()
        {
            // Task1
            BlankReceipt();

            // Task2
            SignOfIntegerNumber();

            // Task3
            PrintingTriangle();

            // Task4
            DrawFilledSquare();

            // Task5
            CalculateTriangleArea();

            // Task6
            MathPower();

            // Task7
            GreaterOfTwoValues();
        }

        private static void BlankReceipt()
        {
            PrintReceipt();
        }

        private static void SignOfIntegerNumber()
        {
            int n = int.Parse(Console.ReadLine());

            PrintSign(n);
        }

        private static void PrintingTriangle()
        {
            int n = int.Parse(Console.ReadLine());

            PrintUpperTrianglePart(n);
            PrintMiddleTrianglePart(n);
            PrintBottomTrianglePart(n);
        }

        private static void DrawFilledSquare()
        {
            int n = int.Parse(Console.ReadLine());

            PrintTopAndBottomLine(n);
            PrintMiddleLines(n);
            PrintTopAndBottomLine(n);
        }

        private static void CalculateTriangleArea()
        {
            double side = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = GetTriangleArea(side, height);

            Console.WriteLine(area);

        }

        private static void MathPower()
        {
            double n = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            double result = CalculateMathPower(n, power);

            Console.WriteLine(result);
        }

        private static void GreaterOfTwoValues()
        {
            string type = Console.ReadLine();
            switch (type)
            {
                case "int":
                    int firstNumber = int.Parse(Console.ReadLine());
                    int secondNumber = int.Parse(Console.ReadLine());
                    int biggerNumber = GetMax(firstNumber, secondNumber);
                    Console.WriteLine(biggerNumber);
                    break;
                case "char":
                    char firstChar = char.Parse(Console.ReadLine());
                    char secondChar = char.Parse(Console.ReadLine());
                    char biggerChar = GetMax(firstChar, secondChar);
                    Console.WriteLine(biggerChar);
                    break;
                case "string":
                    string firstString = Console.ReadLine();
                    string secondString = Console.ReadLine();
                    string biggerString = GetMax(firstString, secondString);
                    Console.WriteLine(biggerString);
                    break;
            }
        }

        private static void PrintReceipt()
        {
            PrintReceiptHeader();
            PrintReceiptBody();
            PrintReceiptFooter();
        }

        private static void PrintReceiptHeader()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
        }

        private static void PrintReceiptBody()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }

        private static void PrintReceiptFooter()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("{0} SoftUni", '\u00A9');
        }

        private static void PrintSign(int n)
        {
            if (n > 0)
                Console.WriteLine($"The number {n} is positive.");
            else if (n < 0)
                Console.WriteLine($"The number {n} is negative.");
            else
                Console.WriteLine($"The number {n} is zero.");
        }

        private static void PrintUpperTrianglePart(int n)
        {
            for (int i = 1; i < n; i++)
            {
                PrintLine(1, i);
            }
        }

        private static void PrintMiddleTrianglePart(int n)
        {
            PrintLine(1, n);
        }

        private static void PrintBottomTrianglePart(int n)
        {
            for (int i = n - 1; i >= 0; i--)
            {
                PrintLine(1, i);
            }
        }

        private static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (i == end)
                    Console.WriteLine(i);
                else
                    Console.Write(i + " ");
            }
        }

        private static void PrintTopAndBottomLine(int number)
        {
            Console.WriteLine(new string('-', number * 2));
        }

        private static void PrintMiddleLines(int number)
        {
            for (int i = 0; i < number - 2; i++)
            {
                Console.Write("-");

                for (int j = 0; j < number - 1; j++)
                {
                    Console.Write("\\/");
                }

                Console.WriteLine("-");
            }
        }

        private static double GetTriangleArea(double side, double height)
        {
            return side * height / 2;
        }

        private static double CalculateMathPower(double number, double power)
        {
            double result = Math.Pow(number, power);
            return result;
        }

        private static int GetMax(int first, int second)
        {
            if (first >= second)
                return first;

            return second;
        }

        private static char GetMax(char first, char second)
        {
            if (first >= second)
                return first;

            return second;
        }

        private static string GetMax(string first, string second)
        {
            if (first.CompareTo(second) >= 0)
                return first;

            return second;
        }
    }
}
