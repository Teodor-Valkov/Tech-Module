namespace _02.CountSubstringOccurrences
{
    using System;

    class CountSubstringOccurrencess
    {
        static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string word = Console.ReadLine().ToLower();

            int counter = 0;
            int index = text.IndexOf(word, StringComparison.Ordinal);

            while (index != -1)
            {
                counter++;
                index = text.IndexOf(word, index + 1, StringComparison.Ordinal);
            }

            Console.WriteLine(counter);
        }
    }
}
