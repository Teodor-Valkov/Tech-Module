namespace _05.MagicExchangeableWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class MagicExchangeableWords
    {
        private static void Main()
        {
            string[] words = Console.ReadLine().Split();

            char[] first = words[0].ToCharArray();
            char[] second = words[1].ToCharArray();

            List<char> list1 = new List<char>();
            List<char> list2 = new List<char>();

            foreach (char letter in first)
            {
                if (list1.All(x => x != letter))
                {
                    list1.Add(letter);
                }
            }

            foreach (char letter in second)
            {
                if (list2.All(x => x != letter))
                {
                    list2.Add(letter);
                }
            }

            Console.WriteLine(list1.Count == list2.Count ? "true" : "false");
        }
    }
}