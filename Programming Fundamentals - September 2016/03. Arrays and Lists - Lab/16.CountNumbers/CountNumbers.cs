namespace _16.CountNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class CountNumbers
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> numsDistinct = numbers.Distinct().OrderBy(x => x).ToList();
            List<int> occurrences = new List<int>();

            foreach (int num in numsDistinct)
            {
                occurrences.Add(numbers.Count(x => x == num));
            }

            for (int i = 0; i < occurrences.Count; i++)
            {
                Console.WriteLine($"{numsDistinct[i]} -> {occurrences[i]}");
            }
        }
    }
}
