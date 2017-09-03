namespace _08.LettersChangeNumbers
{
    using System;
    using System.Linq;

    internal class LettersChangeNumbers
    {
        private static void Main()
        {
            string input = Console.ReadLine();

            if (input != null)
            {
                string[] inputArgs = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                decimal totalSum = 0;

                foreach (string arg in inputArgs)
                {
                    string numberString = string.Empty;
                    foreach (char symbol in arg)
                    {
                        if (char.IsDigit(symbol))
                        {
                            numberString += symbol;
                        }
                    }

                    decimal number = decimal.Parse(numberString);

                    char firstLetter = arg.First();

                    if (firstLetter >= 65 && firstLetter <= 90)
                    {
                        number /= firstLetter - 'A' + 1;
                    }

                    if (firstLetter >= 97 && firstLetter <= 122)
                    {
                        number *= firstLetter - 'a' + 1;
                    }

                    char lastLetter = arg.Last();

                    if (lastLetter >= 65 && lastLetter <= 90)
                    {
                        number -= lastLetter - 'A' + 1;
                    }

                    if (lastLetter >= 97 && lastLetter <= 122)
                    {
                        number += lastLetter - 'a' + 1;
                    }

                    totalSum += number;
                }

                Console.WriteLine($"{totalSum:F2}");
            }
        }
    }
}