namespace _02.RandomizeWords
{
    using System;

    internal class RandomizeWords
    {
        private static void Main()
        {
            string[] words = Console.ReadLine().Split(' ');

            Random rnd = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int position = rnd.Next(0, words.Length);
                string oldValue = words[i];

                words[i] = words[position];
                words[position] = oldValue;
            }

            Console.WriteLine(string.Join("\n", words));
        }
    }
}