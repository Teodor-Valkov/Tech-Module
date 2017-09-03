namespace _06.PrimeChecker
{
    using System;

    internal class PrimeChecker
    {
        private static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            bool isPrime = CheckIfNumberIsPrime(n);

            Console.WriteLine(isPrime);
        }

        private static bool CheckIfNumberIsPrime(long n)
        {
            bool isPrime = true;

            if (n == 0 || n == 1)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                }
            }

            return isPrime;
        }
    }
}