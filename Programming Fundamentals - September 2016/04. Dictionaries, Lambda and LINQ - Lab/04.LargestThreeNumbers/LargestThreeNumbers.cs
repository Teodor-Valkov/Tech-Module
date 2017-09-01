namespace _04.LargestThreeNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class LargestThreeNumbers
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> sortedReversedNumbers = numbers.OrderBy(x => -x).ToList();
            // or Sort() and Reverse();
            // or OrderByDescending();

            List<int> largestThree = sortedReversedNumbers.Take(3).ToList();

            Console.WriteLine(string.Join(", ", largestThree));
        }
    }
}
