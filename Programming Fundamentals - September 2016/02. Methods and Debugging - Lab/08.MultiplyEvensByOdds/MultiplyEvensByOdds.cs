namespace _08.MultiplyEvensByOdds
{
    using System;

    internal class MultiplyEvensByOdds
    {
        private static void Main()
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            int multiplyEvensByOdds = GetMultipleOfEvensAndOdds(number);

            Console.WriteLine(multiplyEvensByOdds);
        }

        private static int GetMultipleOfEvensAndOdds(int number)
        {
            int sumOfEvens = GetSumOfEvenDigits(number);
            int sumOfOdds = GetSumOfOddDigits(number);
            int sumOfEvenAndOdds = sumOfEvens * sumOfOdds;

            return sumOfEvenAndOdds;
        }

        private static int GetSumOfEvenDigits(int number)
        {
            int sumOfEvens = 0;

            while (number > 0)
            {
                int lastDigit = number % 10;

                if (lastDigit % 2 == 0)
                {
                    sumOfEvens += lastDigit;
                }

                number /= 10;
            }

            return sumOfEvens;
        }

        private static int GetSumOfOddDigits(int number)
        {
            int sumOfOdds = 0;

            for (int i = 0; i < number.ToString().Length; i++)
            {
                int currentDigit = int.Parse(number.ToString()[i].ToString());

                if (currentDigit % 2 == 1)
                {
                    sumOfOdds += currentDigit;
                }
            }

            return sumOfOdds;
        }
    }
}