namespace _07.PrimesInGivenRange
{
    using System;
    using System.Collections.Generic;

    class PrimesInGivenRange
    {
        static void Main()
        {
            long startNumber = long.Parse(Console.ReadLine());
            long endNumber = long.Parse(Console.ReadLine());
            List<long> primeNumbers = FindPrimesInRange(startNumber, endNumber);

            Console.WriteLine(string.Join(", ", primeNumbers));
        }

        private static List<long> FindPrimesInRange(long start, long end)
        {
            List<long> primes = new List<long>();

            if (start == 0 || start == 1)
            {
                start = 2;
            }

            for (long i = start; i <= end; i++)
            {
                bool isPrime = true;

                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i%j == 0)
                    {
                        isPrime = false;
                    }
                }

                if (isPrime)
                {
                    primes.Add(i);
                }
            }

            return primes;
        }
    }
}
