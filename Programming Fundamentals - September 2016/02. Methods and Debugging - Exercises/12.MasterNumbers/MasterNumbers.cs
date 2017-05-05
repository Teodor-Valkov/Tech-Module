namespace _12.MasterNumbers
{   
    using System;

    class MasterNumbers
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= number; i++)
            {
                bool isPalindrome = IsPalindrome(i);
                bool isDivisibleBySeven = IsSumDivisibleBySeven(i);
                bool isThereEvenDigit = HasEvenDigit(i);

                if (isPalindrome && isDivisibleBySeven && isThereEvenDigit)
                {
                    Console.WriteLine(i);
                }
            }
        }

         private static bool IsPalindrome(int number)
        {
            bool isPalindrome = true;
            string numberString = number.ToString();

            for (int i = 0; i < numberString.Length / 2; i++)
            {
                if (numberString[i] == numberString[numberString.Length - i - 1])
                {
                    continue;
                }

                isPalindrome = false;
            }

            return isPalindrome;
        }

        private static bool IsSumDivisibleBySeven(int number)
        {
            int sum = 0;

            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            if (sum%7 == 0)
            {
                return true;
            }

            return false;
        }

        private static bool HasEvenDigit(int number)
        {
            while (number > 0)
            {
                int currentDigit = number % 10;

                if (currentDigit%2 == 0)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }
    }
}

