namespace _07.SumArrays
{
    using System;
    using System.Linq;

    internal class SumArrays
    {
        private static void Main()
        {
            int[] firstArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int longestArray = Math.Max(firstArray.Length, secondArray.Length);

            int[] sumArray = new int[longestArray];

            for (int i = 0; i < longestArray; i++)
            {
                sumArray[i] = firstArray[i % firstArray.Length] + secondArray[i % secondArray.Length];
            }

            Console.WriteLine(string.Join(" ", sumArray));
        }
    }
}