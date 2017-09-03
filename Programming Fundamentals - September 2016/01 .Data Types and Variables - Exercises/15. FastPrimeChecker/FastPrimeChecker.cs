namespace _15.FastPrimeChecker
{
    using System;

    internal class FastPrimeChecker
    {
        private static void Main()
        {
            int endNumber = int.Parse(Console.ReadLine());

            for (int currentNumber = 2; currentNumber <= endNumber; currentNumber++)
            {
                bool isPrime = true;

                for (int primeCheckerDivider = 2; primeCheckerDivider <= Math.Sqrt(currentNumber); primeCheckerDivider++)
                {
                    if (currentNumber % primeCheckerDivider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                Console.WriteLine($"{currentNumber} -> {isPrime}");
            }
        }
    }
}