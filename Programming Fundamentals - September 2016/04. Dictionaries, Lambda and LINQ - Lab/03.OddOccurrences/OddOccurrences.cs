namespace _03.OddOccurrences
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class OddOccurrences
    {
        static void Main()
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
