namespace _11.EqualSums
{
    using System;
    using System.Linq;

    class EqualSums
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool answer = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                int leftSum = 0;

                for (int j = 0; j < i; j++)
                {
                    leftSum += numbers[j];
                }

                int rightSum = 0;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    rightSum += numbers[j];
                }

                if (leftSum == rightSum)
                {
                    answer = true;
                    int indexAnswer = i;

                    Console.WriteLine(indexAnswer);
                }
            }
            if (!answer)
            {
                Console.WriteLine("no");
            }
        }
    }
}
