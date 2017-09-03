namespace _11.AppendLists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class AppendLists
    {
        private static void Main()
        {
            List<string> manyLists = Console.ReadLine().Split('|').ToList();
            List<string> answerLists = new List<string>();

            for (int i = manyLists.Count - 1; i >= 0; i--)
            {
                string[] currentList = manyLists[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string letter in currentList)
                {
                    if (letter != "")
                    {
                        answerLists.Add(letter);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", answerLists));
        }
    }
}