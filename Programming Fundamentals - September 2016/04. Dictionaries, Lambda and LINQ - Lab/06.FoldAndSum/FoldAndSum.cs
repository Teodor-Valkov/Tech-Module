namespace _06.FoldAndSum
{
    using System;
    using System.Linq;

    class FoldAndSum
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int part = numbers.Length / 4;
            
            int[] firstPart = numbers.Take(part).Reverse().ToArray();
            int[] middlePart = numbers.Skip(part).Take(part * 2).ToArray();
            int[] thirdPart = numbers.Reverse().Take(part).ToArray();

            int[] firstRow = firstPart.Concat(thirdPart).ToArray();
            int[] secondRow = middlePart;

            int[] sumNumbersOfTheRows = firstRow.Select((x, index) => x + secondRow[index]).ToArray();

            //int[] sumNumbersOfTheRows = new int[firstRow.Length];
            //for (int i = 0; i < firstRow.Length; i++)
            //{
            //    sumNumbersOfTheRows[i] = firstRow[i] + secondRow[i];
            //}

            Console.WriteLine(string.Join(" ", sumNumbersOfTheRows));
       }
    }
}
