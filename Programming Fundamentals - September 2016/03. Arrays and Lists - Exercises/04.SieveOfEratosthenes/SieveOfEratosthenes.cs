namespace _04.SieveOfEratosthenes
{
    using System;

    internal class SieveOfEratosthenes
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            bool[] primes = new bool[n + 1];

            for (int i = 2; i <= n; i++)
            {
                primes[i] = true;
            }

            for (int currentNumber = 2; currentNumber <= n; currentNumber++)
            {
                if (primes[currentNumber])
                {
                    Console.WriteLine(currentNumber);

                    for (int i = currentNumber * 2; i < primes.Length; i += currentNumber)
                    {
                        primes[i] = false;
                    }
                }
            }
        }
    }
}