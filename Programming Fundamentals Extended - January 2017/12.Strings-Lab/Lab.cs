namespace _12.Strings_Lab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Lab
    {
        private static void Main()
        {
            // Task 1
            ReverseString();

            // Task 2
            CountSubstringOccurrences();

            // Task 3
            TextFilter();

            // Task 4
            Palindromes();
        }

        private static void ReverseString()
        {
            string input = Console.ReadLine();

            if (input != null)
            {
                char[] reversedInput = input.ToCharArray();
                Array.Reverse(reversedInput);

                Console.WriteLine(string.Join("", reversedInput));
            }
        }

        private static void CountSubstringOccurrences()
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

        private static void TextFilter()
        {
            string[] forbiddenWords = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (string forbiddenWord in forbiddenWords)
            {
                if (text != null && text.Contains(forbiddenWord))
                {
                    text = text.Replace(forbiddenWord, new string('*', forbiddenWord.Length));
                }
            }

            Console.WriteLine(text);
        }

        private static void Palindromes()
        {
            string[] words = Console.ReadLine()
                .Split(new[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> palindromes = new List<string>();

            foreach (string word in words)
            {
                bool isPalinrome = FindIfWordIsPalindrome(word);

                if (isPalinrome)
                {
                    palindromes.Add(word);
                }
            }

            palindromes = palindromes.Distinct().OrderBy(x => x).ToList();

            Console.WriteLine(string.Join(", ", palindromes));
        }

        private static bool FindIfWordIsPalindrome(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] == word[word.Length - i - 1])
                {
                    continue;
                }

                return false;
            }

            return true;
        }
    }
}