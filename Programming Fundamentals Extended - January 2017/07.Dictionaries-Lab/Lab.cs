namespace _07.Dictionaries_Lab
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Lab
    {
        static void Main()
        {
            // Task 1
            CountRealNumbers();

            // Task 2
            OddOccurrences();
        }

        private static void CountRealNumbers()
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
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }

        private static void OddOccurrences()
        {
            List<string> words = Console.ReadLine().ToLower().Split(' ').ToList();
            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (counts.ContainsKey(word))
                {
                    counts[word]++;
                }
                else
                {
                    counts[word] = 1;
                }
            }

            List<string> result = new List<string>();
            //or result = counts.Where(pair => pair.Value % 2 != 0).Select(pair => pair.Key).ToList();

            foreach (KeyValuePair<string, int> pair in counts)
            {
                if (pair.Value % 2 != 0)
                {
                    result.Add(pair.Key);
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
