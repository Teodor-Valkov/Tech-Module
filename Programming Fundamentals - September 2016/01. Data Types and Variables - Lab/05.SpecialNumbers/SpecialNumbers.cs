namespace _05.SpecialNumbers
{
    using System;

    class SpecialNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= n; i++)
            {
                int currentNumber = i;
                int sum = SumOfDigits(currentNumber);
                bool equal = sum == 5 || sum == 7 || sum == 11;

                Console.WriteLine($"{i} -> {equal}");
            }
        }

        public static int SumOfDigits(int currentNumber)
        {
            int sum = 0;

            while (currentNumber != 0)
            {
                sum += currentNumber % 10;
                currentNumber /= 10;
            }

            return sum;
        }
    }
}
