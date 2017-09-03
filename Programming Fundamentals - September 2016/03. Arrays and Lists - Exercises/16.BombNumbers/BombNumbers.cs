namespace _16.BombNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class BombNumbers
    {
        private static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] actions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int toDestroy = actions[0];
            int power = actions[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                int position = numbers.IndexOf(toDestroy);

                if (position == -1)
                    break;

                int leftSide = Math.Max(0, position - power);
                int rightSide = Math.Min(numbers.Count - 1, position + power);

                int length = rightSide - leftSide + 1;

                numbers.RemoveRange(leftSide, length);
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}