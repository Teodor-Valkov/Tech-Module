namespace _01.DataTypes_Exercises
{
    using System;
    using System.Globalization;
    using System.Linq;

    internal class Exercises
    {
        private static void Main()
        {
            // Task 1
            PracticeIntegerNumbers();

            // Task 2
            PracticeFloatingPointNumbers();

            // Task 3
            ExchangeVariableValues();

            // Task 4
            FloatOrInteger();

            // Task 5
            DistanceOfTheStars();

            // Task 6
            IncrementVariable();

            // Task 7
            FromTerabytesToBytes();

            // Task 8
            TravelingAtLigthSpeed();

            // Task 9
            TriangleFormations();

            // Task 10
            DataOverflow();

            // Task 11
            PracticeCharactersAndStrings();

            // Task 12
            VariableInHexadecimalFormat();

            // Task 13
            DigitsWithWords();

            // Task 14
            AsciiString();

            // Task 15
            Calculator();

            // Task 16
            TrickyStrings();

            // Task 17
            CypherRoulette();
        }

        private static void PracticeIntegerNumbers()
        {
            sbyte num1 = -100;
            byte num2 = 128;
            short num3 = -3540;
            ushort num4 = 64876;
            uint num5 = 2147483648;
            int num6 = -1141583228;
            long num7 = -1223372036854775808;

            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.WriteLine(num3);
            Console.WriteLine(num4);
            Console.WriteLine(num5);
            Console.WriteLine(num6);
            Console.WriteLine(num7);
        }

        private static void PracticeFloatingPointNumbers()
        {
            decimal num1 = 3.141592653589793238m;
            double num2 = 1.60217657;
            decimal num3 = 7.8184261974584555216535342341m;

            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.WriteLine(num3);
        }

        private static void ExchangeVariableValues()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("Before:");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");

            int c = a;
            a = b;
            b = c;

            Console.WriteLine("After:");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
        }

        private static void FloatOrInteger()
        {
            string numberAsString = Console.ReadLine();
            int number = 0;

            bool isNumberInteger = int.TryParse(numberAsString, out number);
            if (isNumberInteger)
            {
                Console.WriteLine(number);
            }
            else
            {
                if (numberAsString != null)
                {
                    Console.WriteLine(Math.Round(double.Parse(numberAsString)));
                }
            }
        }

        private static void DistanceOfTheStars()
        {
            decimal proximaCentauri = 4.22m * 9450000000000m;
            decimal milkyWay = 26000m * 9450000000000m;
            decimal radiusMilkyWay = 100000m * 9450000000000m;
            decimal distanceEarth = 46500000000m * 9450000000000m;

            Console.WriteLine($"{proximaCentauri:e2}");
            Console.WriteLine($"{milkyWay:e2}");
            Console.WriteLine($"{radiusMilkyWay:e2}");
            Console.WriteLine($"{distanceEarth:e2}");
        }

        private static void IncrementVariable()
        {
            int number = int.Parse(Console.ReadLine());
            int overflows = 0;
            byte result = 0;

            for (int i = 0; i < number; i++)
            {
                result++;
                if (result == 0)
                {
                    overflows++;
                }
            }

            Console.WriteLine(result);
            Console.WriteLine($"Overflowed {overflows} times");
        }

        private static void FromTerabytesToBytes()
        {
            decimal terabytes = decimal.Parse(Console.ReadLine());
            decimal bytes = terabytes * 1024 * 1024 * 1024 * 1024 * 8;

            Console.WriteLine($"{bytes:F0}");
        }

        private static void TravelingAtLigthSpeed()
        {
            decimal lightYears = decimal.Parse(Console.ReadLine());

            decimal lightYearInKm = 9450000000000m;
            decimal speedOfLight = 300000m;

            decimal total = (lightYearInKm / speedOfLight) * lightYears;

            TimeSpan diff = TimeSpan.FromSeconds((double)total);

            string formatted = string.Format(CultureInfo.CurrentCulture,
                  "{0} weeks\n{1} days\n{2} hours\n{3} minutes\n{4} seconds",
                  diff.Days / 7,
                  diff.Days % 7,
                  diff.Hours,
                  diff.Minutes,
                  diff.Seconds);

            Console.WriteLine(formatted);
        }

        private static void TriangleFormations()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int[] array = { a, b, c };
            array = array.OrderBy(side => side).ToArray();

            int sideA = array[0];
            int sideB = array[1];
            int sideC = array[2];

            bool isTriangleValid = false;
            bool rightAngle = Math.Pow(sideA, 2) + Math.Pow(sideB, 2) == Math.Pow(sideC, 2);

            if (a + b > c)
            {
                if (a + c > b)
                {
                    if (b + c > a)
                    {
                        isTriangleValid = true;
                    }
                }
            }

            if (isTriangleValid)
            {
                Console.WriteLine("Triangle is valid.");
                if (rightAngle)
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
            else
            {
                Console.WriteLine("Invalid Triangle.");
            }
        }

        private static void DataOverflow()
        {
            ulong firstNum = ulong.Parse(Console.ReadLine());
            ulong secondNum = ulong.Parse(Console.ReadLine());

            ulong biggerNum = Math.Max(firstNum, secondNum);
            ulong smallerNum = Math.Min(firstNum, secondNum);

            string bigType = "";
            string smallType = "";
            ulong smallNumTypeValue = 0;

            if (biggerNum >= smallerNum)
            {
                if (biggerNum > byte.MinValue && biggerNum <= byte.MaxValue)
                {
                    bigType = "byte";
                }
                else if (biggerNum > ushort.MinValue && biggerNum <= ushort.MaxValue)
                {
                    bigType = "ushort";
                }
                else if (biggerNum > uint.MinValue && biggerNum <= uint.MaxValue)
                {
                    bigType = "uint";
                }
                else if (biggerNum > ulong.MinValue)
                {
                    bigType = "ulong";
                }

                if (smallerNum > byte.MinValue && smallerNum <= byte.MaxValue)
                {
                    smallType = "byte";
                    smallNumTypeValue = byte.MaxValue;
                }
                else if (smallerNum > ushort.MinValue && smallerNum <= ushort.MaxValue)
                {
                    smallType = "ushort";
                    smallNumTypeValue = ushort.MaxValue;
                }
                else if (smallerNum > uint.MinValue && smallerNum <= uint.MaxValue)
                {
                    smallType = "uint";
                    smallNumTypeValue = uint.MaxValue;
                }
                else if (smallerNum > ulong.MinValue)
                {
                    smallType = "ulong";
                    smallNumTypeValue = ulong.MaxValue;
                }

                Console.WriteLine($"bigger type: {bigType}");
                Console.WriteLine($"smaller type: {smallType}");
                Console.WriteLine($"{biggerNum} can overflow {smallType} {Math.Round((double)biggerNum / smallNumTypeValue)} times");
            }
        }

        private static void PracticeCharactersAndStrings()
        {
            string text1 = "Software University";
            char text2 = 'B';
            char text3 = 'y';
            char text4 = 'e';
            string text5 = "I love programming";

            Console.WriteLine(text1);
            Console.WriteLine(text2);
            Console.WriteLine(text3);
            Console.WriteLine(text4);
            Console.WriteLine(text5);
        }

        private static void VariableInHexadecimalFormat()
        {
            string input = Console.ReadLine();
            int number = Convert.ToInt32(input, 16);

            Console.WriteLine(number);
        }

        private static void DigitsWithWords()
        {
            string numberAsString = Console.ReadLine();
            int number = 0;

            switch (numberAsString)
            {
                case "zero": number = 0; break;
                case "one": number = 1; break;
                case "two": number = 2; break;
                case "three": number = 3; break;
                case "four": number = 4; break;
                case "five": number = 5; break;
                case "six": number = 6; break;
                case "seven": number = 7; break;
                case "eight": number = 8; break;
                case "nine": number = 9; break;
            }

            Console.WriteLine(number);
        }

        private static void AsciiString()
        {
            int number = int.Parse(Console.ReadLine());
            string result = string.Empty;

            for (int i = 0; i < number; i++)
            {
                int asciiCode = int.Parse(Console.ReadLine());
                char letter = (char)asciiCode;
                result += letter;
            }

            Console.WriteLine(result);
        }

        private static void Calculator()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            char mathOperator = char.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            int result = 0;

            switch (mathOperator)
            {
                case '-': result = firstNumber - secondNumber; break;
                case '+': result = firstNumber + secondNumber; break;
                case '*': result = firstNumber * secondNumber; break;
                case '/': result = firstNumber / secondNumber; break;
            }

            Console.WriteLine($"{firstNumber} {mathOperator} {secondNumber} = {result}");
        }

        private static void TrickyStrings()
        {
            string delimiter = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            string result = "";

            for (int i = 0; i < number; i++)
            {
                string word = Console.ReadLine();

                if (i == number - 1)
                {
                    result += word;
                }
                else
                {
                    result += word + delimiter;
                }
            }

            Console.WriteLine($"{result}");
        }

        private static void CypherRoulette()
        {
            int number = int.Parse(Console.ReadLine());

            string lastWord = string.Empty;
            bool switchDirection = false;
            string result = string.Empty;

            for (int i = 0; i < number; i++)
            {
                string word = Console.ReadLine();

                if (word == "spin")
                {
                    switchDirection = !switchDirection;
                    i--;
                }

                if (!switchDirection)
                {
                    result += word;
                }
                if (switchDirection)
                {
                    result = word + result;
                }

                if (lastWord == word)
                {
                    result = string.Empty;

                    if (lastWord == "spin" && word == "spin")
                    {
                        switchDirection = !switchDirection;
                    }
                }

                lastWord = word;
            }

            result = result.Replace("spin", string.Empty);
            Console.WriteLine(result);
        }
    }
}