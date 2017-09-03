namespace _03.WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class WordCount
    {
        private static void Main()
        {
            string separators = "/n/r,.!?- ";

            string[] text = File.ReadAllText("New folder/input.txt").ToLower().Split(separators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string[] words = File.ReadAllText("New folder/words.txt").ToLower().Split(' ');
            //string[] words = File.ReadAllLines("New folder/words.txt");
            //If the sentences are separated in new lines, the method itself splits them in new lines

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach (string word in words)
            {
                wordCount[word] = 0;
            }

            foreach (string word in text)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
            }

            foreach (KeyValuePair<string, int> pair in wordCount.OrderByDescending(x => x.Value))
            {
                File.AppendAllText("Output/output.txt", $"{pair.Key} - {pair.Value}{Environment.NewLine}");
            }
        }
    }
}