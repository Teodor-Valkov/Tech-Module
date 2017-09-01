namespace _09.IndexOfLetters
{
    using System;

    class IndexOfLetters
    {
        static void Main()
        {
            string input = Console.ReadLine();
            
            // First Solution
            foreach (char symbol in input)
            {
                char currentLetter = Convert.ToChar(symbol); //or (char)(input[i]);
                int currentLetterIndex = currentLetter - 'a';

                Console.WriteLine("{0} -> {1}", currentLetter, currentLetterIndex);
            }

            // Second Solution
            //foreach (char letter in input)
            //{
            //    int currentLetterIndex = letter - 'a';
            //
            //    Console.WriteLine("{0} -> {1}", letter, currentLetterIndex);
            //}
        }
    }
}
