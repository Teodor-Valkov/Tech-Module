namespace _03.FoldAndSum
{
    using System;
    using System.Linq;

    internal class FoldAndSum
    {
        private static void Main()
        {
            //First Solution
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] firstArray = new int[numbers.Length / 4];
            int[] secondArray = new int[numbers.Length / 2];
            int[] thirdArray = new int[numbers.Length / 4];

            FirstGroupOfDigits(numbers, firstArray);
            SecondGroupOfDigits(numbers, firstArray, secondArray);
            ThirdGroupOfDigits(numbers, thirdArray);

            int[] firstHalfResult = new int[firstArray.Length];

            for (int i = 0; i < firstHalfResult.Length; i++)
            {
                firstHalfResult[i] = firstArray[i] + secondArray[i];
            }

            int[] secondHalfResult = new int[thirdArray.Length];

            for (int i = 0; i < secondHalfResult.Length; i++)
            {
                secondHalfResult[i] = thirdArray[i] + secondArray[thirdArray.Length + i];
            }

            Console.Write(string.Join(" ", firstHalfResult));
            Console.WriteLine(" " + string.Join(" ", secondHalfResult));

            //Second Solution
            //int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //int k = numbers.Length / 4;

            //int[] firstLeftRow = numbers.Take(k).Reverse().ToArray();
            //int[] firstRightRow = numbers.Reverse().Take(k).ToArray();

            //int[] firstRow = firstLeftRow.Concat(firstRightRow).ToArray();
            //int[] secondRow = numbers.Skip(k).Take(2 * k).ToArray();

            //int[] sumNumbersOfTheRows = firstRow.Select((x, index) => x + secondRow[index]).ToArray();
            //Console.WriteLine(string.Join(" ", sumNumbersOfTheRows));
        }

        private static void FirstGroupOfDigits(int[] numbers, int[] firstArray)
        {
            for (int i = 0; i < firstArray.Length; i++)
            {
                firstArray[i] = numbers[numbers.Length / 4 - i - 1];
            }
        }

        private static void SecondGroupOfDigits(int[] numbers, int[] firstArray, int[] secondArray)
        {
            for (int i = 0; i < secondArray.Length; i++)
            {
                secondArray[i] = numbers[firstArray.Length + i];
            }
        }

        private static void ThirdGroupOfDigits(int[] numbers, int[] thirdArray)
        {
            for (int i = 0; i < thirdArray.Length; i++)
            {
                thirdArray[i] = numbers[numbers.Length - i - 1];
            }
        }
    }
}