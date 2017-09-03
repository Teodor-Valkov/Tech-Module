namespace _03.EnglishNameOfTheLastDigit
{
    using System;
    using System.Linq;

    internal class EnglishNameOfTheLastDigit
    {
        private static void Main()
        {
            string n = Console.ReadLine();
            string lastDigitEnglishName = GetLastDigitEnglishName(n);

            Console.WriteLine(lastDigitEnglishName);
        }

        private static string GetLastDigitEnglishName(string number)
        {
            string lastDigitName = string.Empty;

            switch (number.Last())
            {
                case '0': lastDigitName = "zero"; break;
                case '1': lastDigitName = "one"; break;
                case '2': lastDigitName = "two"; break;
                case '3': lastDigitName = "three"; break;
                case '4': lastDigitName = "four"; break;
                case '5': lastDigitName = "five"; break;
                case '6': lastDigitName = "six"; break;
                case '7': lastDigitName = "seven"; break;
                case '8': lastDigitName = "eight"; break;
                case '9': lastDigitName = "nine"; break;
            }

            return lastDigitName;
        }
    }
}