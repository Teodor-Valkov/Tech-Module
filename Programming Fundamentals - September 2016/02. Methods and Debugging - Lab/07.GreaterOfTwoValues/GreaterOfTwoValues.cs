namespace _07.GreaterOfTwoValues
{
    using System;

    class GreaterOfTwoValues
    {
        static void Main()
        {
            string type = Console.ReadLine();
            switch (type)
            {
                case "int" :
                    int firstNumber = int.Parse(Console.ReadLine());
                    int secondNumber = int.Parse(Console.ReadLine());
                    int biggerNumber = GetMax(firstNumber, secondNumber);
                    Console.WriteLine(biggerNumber);
                    break;
                case "char" :
                    char firstChar = char.Parse(Console.ReadLine());
                    char secondChar = char.Parse(Console.ReadLine());
                    char biggerChar = GetMax(firstChar, secondChar);
                    Console.WriteLine(biggerChar);
                    break;
                case "string" :
                    string firstString= Console.ReadLine();
                    string secondString = Console.ReadLine();
                    string biggerString = GetMax(firstString, secondString);
                    Console.WriteLine(biggerString);
                    break;
            }
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

        private static string GetMax(string first,string second)
        {
            if (first.CompareTo(second) >= 0)
                return first;

            return second;
        }
    }
}
