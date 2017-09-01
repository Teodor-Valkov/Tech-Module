namespace _01.CountRealNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class CountRealNumbers
    {
        static void Main()
        {
            List<double> numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();

            foreach (double number in numbers)
            {
                if (counts.ContainsKey(number))
                {
                    counts[number]++;
                }
                else
                {
                    counts[number] = 1;
                }
            }

            foreach (KeyValuePair<double, int> pair in counts)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}
