namespace _04.NumbersInReversedOrder
{
    using System;

    class NumbersInReversedOrder
    {
        static void Main()
        {
            //Two solutions with a method with overloads:

            string numString = Console.ReadLine();
            char[] numCharArray = numString.ToCharArray();

            string reversedNumString = GetReversedNumber(numString);
            char[] reversedNumCharArray = GetReversedNumber(numCharArray);
    
            Console.WriteLine(reversedNumString);
            Console.WriteLine(reversedNumCharArray);
        }

        private static string GetReversedNumber(string number)
        {
            string reversedNumber = string.Empty;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                reversedNumber += number[i];
            }

            return reversedNumber;
        }

        private static char[] GetReversedNumber(char[] number)
        {
            Array.Reverse(number);
            return number;
        }
    }
}
