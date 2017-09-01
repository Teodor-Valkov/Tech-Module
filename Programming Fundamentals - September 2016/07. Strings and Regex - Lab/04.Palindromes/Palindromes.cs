namespace _04.Palindromes
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Palindromes
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split(new [] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

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

            Console.WriteLine(string.Join (", ", palindromes));
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
