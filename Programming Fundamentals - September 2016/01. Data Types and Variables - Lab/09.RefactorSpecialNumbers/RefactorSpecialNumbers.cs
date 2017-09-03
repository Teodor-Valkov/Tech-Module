namespace _09.RefactorSpecialNumbers
{
    using System;

    internal class RefactorSpecialNumbers
    {
        private static void Main()
        {
            int numbers = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= numbers; i++)
            {
                int currentNumber = i;

                while (currentNumber > 0)
                {
                    sum += currentNumber % 10;
                    currentNumber = currentNumber / 10;
                }

                bool answer = (sum == 5) || (sum == 7) || (sum == 11);

                sum = 0;

                Console.WriteLine($"{i} -> {answer}");
            }
        }
    }
}