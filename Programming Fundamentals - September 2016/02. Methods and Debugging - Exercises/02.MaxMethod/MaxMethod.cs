namespace _02.MaxMethod
{
    using System;

    internal class MaxMethod
    {
        private static void Main()
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int max = GetMax(GetMax(first, second), third);
            Console.WriteLine(max);
        }

        private static int GetMax(int firstNumber, int secondNumber)
        {
            return firstNumber >= secondNumber ? firstNumber : secondNumber;
        }
    }
}