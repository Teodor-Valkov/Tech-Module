namespace _10.RemoveNegativesAndReverse
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class RemoveNegativesAndReverse
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("empty");
            }

            numbers.Reverse();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
