namespace _14.FactorialTrailingZeroes
{
    using System;
    using System.Numerics;

    internal class FactorialTrailingZeroes
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            BigInteger factorial = 1;

            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            int trailingZeroesCounter = GetZeroesInFactorial(factorial);

            Console.WriteLine(trailingZeroesCounter);
        }

        private static int GetZeroesInFactorial(BigInteger factorial)
        {
            int counter = 0;

            while (true)
            {
                BigInteger currentDigit = factorial % 10;

                if (currentDigit == 0)
                {
                    counter++;
                    factorial /= 10;
                    continue;
                }

                return counter;
            }

            //Solution with string:
            //
            //string factorialString = factorial.ToString();

            //for (int i = factorialString.Length - 1; i >= 0; i--)
            //{
            //    int currentDigit = int.Parse(factorialString[i].ToString());

            //    if (currentDigit == 0)
            //        counter++;
            //    else
            //        break;
            //}

            //return counter;
        }
    }
}