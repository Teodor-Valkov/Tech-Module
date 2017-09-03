namespace _02.Methods_Exercises
{
    using System;
    using System.Linq;

    internal class Exercises
    {
        private static void Main()
        {
            // Task 1
            HelloName();

            // Task 2
            MinMethod();

            // Task 3
            StringRepeater();

            // Task 4
            NthDigit();

            // Task 5
            IntegerToBase();

            // Task 6
            Notifications();

            // Task 7
            NumbersToWords();

            // Task 8
            StringEcryption();
        }

        private static void HelloName()
        {
            string name = Console.ReadLine();
            PrintName(name);
        }

        private static void MinMethod()
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int max = GetMin(GetMin(first, second), third);
            Console.WriteLine(max);
        }

        private static void StringRepeater()
        {
            string input = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            string result = RepeatString(input, number);
            Console.WriteLine(result);
        }

        private static void NthDigit()
        {
            int number = int.Parse(Console.ReadLine());
            int index = int.Parse(Console.ReadLine());

            int result = FindNthDigit(number, index);
            Console.WriteLine(result);
        }

        private static void IntegerToBase()
        {
            long number = long.Parse(Console.ReadLine());
            long baseNumber = long.Parse(Console.ReadLine());

            string result = ConvertIntegerToBase(number, baseNumber);
            Console.WriteLine(result);
        }

        private static void Notifications()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string successOrError = Console.ReadLine();
                string operation = Console.ReadLine();

                switch (successOrError)
                {
                    case "success":
                        string message = Console.ReadLine();
                        string success = ShowSuccess(operation, message);

                        Console.WriteLine(success);
                        break;

                    case "error":
                        int code = int.Parse(Console.ReadLine());
                        string error = ShowError(operation, code);

                        Console.WriteLine(error);
                        break;
                }
            }
        }

        private static void NumbersToWords()
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number > 999)
                {
                    Console.WriteLine("too large");
                    continue;
                }

                if (number < -999)
                {
                    Console.WriteLine("too small");
                    continue;
                }

                if (number < 100 && number > -100)
                {
                    continue;
                }

                Letterize(number);
            }
        }

        private static void StringEcryption()
        {
            int number = int.Parse(Console.ReadLine());

            string result = string.Empty;

            for (int i = 0; i < number; i++)
            {
                char letter = Convert.ToChar(Console.ReadLine());
                result += Encrypt(letter);
            }

            Console.WriteLine(result);
        }

        private static void PrintName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        private static int GetMin(int firstNumber, int secondNumber)
        {
            return firstNumber <= secondNumber ? firstNumber : secondNumber;
        }

        private static string RepeatString(string input, int number)
        {
            string repeatedString = string.Empty;

            for (int i = 0; i < number; i++)
            {
                repeatedString += input;
            }

            return repeatedString;
        }

        private static int FindNthDigit(int number, int index)
        {
            int result = 0;
            int counter = 1;

            while (number > 0)
            {
                if (index == counter)
                {
                    result = number % 10;
                    break;
                }

                number /= 10;
                counter++;
            }

            return result;
        }

        private static string ConvertIntegerToBase(long number, long baseNumber)
        {
            string newNumber = string.Empty;

            while (number > 0)
            {
                newNumber = number % baseNumber + newNumber;
                number = number / baseNumber;
            }

            return newNumber;
        }

        private static string ShowSuccess(string operation, string message)
        {
            return $"Successfully executed {operation}.\n==============================\nMessage: {message}.";
        }

        private static string ShowError(string operation, int code)
        {
            return code > 0
                ? $"Error: Failed to execute {operation}.\n==============================\nError Code: {code}.\nReason: Invalid Client Data."
                : $"Error: Failed to execute {operation}.\n==============================\nError Code: {code}.\nReason: Internal System Failure.";
        }

        private static void Letterize(int number)
        {
            if (number < 0)
            {
                Console.Write("minus ");
                number *= -1;
            }

            switch (number / 100)
            {
                case 1: Console.Write("one-hundred "); break;
                case 2: Console.Write("two-hundred "); break;
                case 3: Console.Write("three-hundred "); break;
                case 4: Console.Write("four-hundred "); break;
                case 5: Console.Write("five-hundred "); break;
                case 6: Console.Write("six-hundred "); break;
                case 7: Console.Write("seven-hundred "); break;
                case 8: Console.Write("eight-hundred "); break;
                case 9: Console.Write("nine-hundred "); break;
            }
            if (number % 100 < 20)
            {
                switch (number % 100)
                {
                    case 00: Console.WriteLine(); break;
                    case 01: Console.WriteLine("and one"); break;
                    case 02: Console.WriteLine("and two"); break;
                    case 03: Console.WriteLine("and three"); break;
                    case 04: Console.WriteLine("and four"); break;
                    case 05: Console.WriteLine("and five"); break;
                    case 06: Console.WriteLine("and six"); break;
                    case 07: Console.WriteLine("and seven"); break;
                    case 08: Console.WriteLine("and eight"); break;
                    case 09: Console.WriteLine("and nine"); break;
                    case 10: Console.WriteLine("and ten"); break;
                    case 11: Console.WriteLine("and eleven"); break;
                    case 12: Console.WriteLine("and twelve"); break;
                    case 13: Console.WriteLine("and thirteen"); break;
                    case 14: Console.WriteLine("and fourteen"); break;
                    case 15: Console.WriteLine("and fifteen"); break;
                    case 16: Console.WriteLine("and sixteen"); break;
                    case 17: Console.WriteLine("and seventeen"); break;
                    case 18: Console.WriteLine("and eighteen"); break;
                    case 19: Console.WriteLine("and nineteen"); break;
                }
            }
            else
            {
                switch (number / 10 % 10)
                {
                    case 2: Console.Write("and twenty "); break;
                    case 3: Console.Write("and thirty "); break;
                    case 4: Console.Write("and fourty "); break;
                    case 5: Console.Write("and fifty "); break;
                    case 6: Console.Write("and sixty "); break;
                    case 7: Console.Write("and seventy "); break;
                    case 8: Console.Write("and eighty "); break;
                    case 9: Console.Write("and ninety "); break;
                }
                if (number / 10 % 10 != 0)
                {
                    switch (number % 10)
                    {
                        case 0: Console.WriteLine(); break;
                        case 1: Console.WriteLine("one"); break;
                        case 2: Console.WriteLine("two"); break;
                        case 3: Console.WriteLine("three"); break;
                        case 4: Console.WriteLine("four"); break;
                        case 5: Console.WriteLine("five"); break;
                        case 6: Console.WriteLine("six"); break;
                        case 7: Console.WriteLine("seven"); break;
                        case 8: Console.WriteLine("eight"); break;
                        case 9: Console.WriteLine("nine"); break;
                    }
                }
            }
        }

        private static string Encrypt(char letter)
        {
            string result = string.Empty;

            int letterAsNumber = letter;
            string numberAsString = letterAsNumber.ToString();

            result = numberAsString.First() + numberAsString.Last().ToString();

            char nextLetter = Convert.ToChar(letter + int.Parse(numberAsString.Last().ToString()));
            char previousLetter = Convert.ToChar(letter - int.Parse(numberAsString.First().ToString()));

            result = nextLetter + result + previousLetter;
            return result;
        }
    }
}