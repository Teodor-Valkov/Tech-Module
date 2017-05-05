namespace _13.SplitByWordCasing
{
    using System;
    using System.Collections.Generic;

    class SplitByWordCasing
    {
        static void Main()
        {
            string separators = ",;:.!()\'\"/\\[] ";
            string[] input = Console.ReadLine().Split(separators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            List<string> lowerCaseList = new List<string>();
            List<string> mixedCaseList = new List<string>();
            List<string> upperCaseList = new List<string>();

            foreach (string word in input)
            {
                int lowerLetters = 0;
                int upperLetters = 0;

                foreach (char letter in word)
                {
                    if (char.IsLower(letter))
                    {
                        lowerLetters++;
                    }

                    if (char.IsUpper(letter))
                    {
                        upperLetters++;
                    }
                }

                if (lowerLetters == word.Length)
                {
                    lowerCaseList.Add(word);
                }
                else if (upperLetters == word.Length)
                {
                    upperCaseList.Add(word);
                }
                else
                {
                    mixedCaseList.Add(word);
                }
            }

            Console.WriteLine("Lower-case: " + string.Join(", ", lowerCaseList));
            Console.WriteLine("Mixed-case: " + string.Join(", ", mixedCaseList));
            Console.WriteLine("Upper-case: " + string.Join(", ", upperCaseList));
        }
    }
}
