namespace _05.FibonacciNumbers
{
    using System;

    class FibonacciNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int fibonacciNumber = GetFibonacciNumber(n);

            Console.WriteLine(fibonacciNumber);
        }

        private static int GetFibonacciNumber(int n)
        {
            int firstNumber = 0;
            int secondNumber = 1;
            int nextNumber = firstNumber + secondNumber;

            for (int i = 2; i <= n; i++)
            {
                firstNumber = secondNumber;
                secondNumber = nextNumber;
                nextNumber = firstNumber + secondNumber;
            }

            return nextNumber;
        }
    }
}
