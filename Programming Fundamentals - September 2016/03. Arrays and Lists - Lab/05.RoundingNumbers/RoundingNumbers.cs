namespace _05.RoundingNumbers
{
    using System;
    using System.Linq;

    internal class RoundingNumbers
    {
        private static void Main()
        {
            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            int[] roundedNumbers = new int[numbers.Length];

            for (int i = 0; i < roundedNumbers.Length; i++)
            {
                roundedNumbers[i] = (int)Math.Round(numbers[i], MidpointRounding.AwayFromZero);
            }

            for (int i = 0; i < roundedNumbers.Length; i++)
            {
                Console.WriteLine($"{numbers[i]} => {roundedNumbers[i]}");
            }
        }
    }
}