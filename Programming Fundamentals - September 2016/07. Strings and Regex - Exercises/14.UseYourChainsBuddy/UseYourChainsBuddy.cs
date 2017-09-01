namespace _14.UseYourChainsBuddy
{
    using System;
    using System.Text.RegularExpressions;

    class UseYourChainsBuddy
    {
        static void Main()
        {
            string input = Console.ReadLine();

            // First pattern gets all the <p> tags in different matches using the lazy quantifier "?"
            // Second pattern gets all the <p> tags in diffrent matches using the exclusion in the matches of "/"

            string pattern = @"<p>(.+?)<\/p>";
            //string pattern2 = @"<p>(.[^\/]+)<\/p>";

            string symbolsToSpace = @"[^a-z0-9]+";

            Regex regex = new Regex(pattern);

            if (input != null)
            {
                MatchCollection matches = regex.Matches(input);
                string encrypted = "";

                for (int i = 0; i < matches.Count; i++)
                {
                    string text = matches[i].Groups[1].Value;
                    encrypted += Regex.Replace(text, symbolsToSpace, " ");
                }

                string result = string.Empty;

                foreach (char symbol in encrypted)
                {
                    if (symbol >= 'a' && symbol <= 'm')
                    {
                        result += (char)(symbol + 13);
                    }
                    else if (symbol >= 'n' && symbol <= 'z')
                    {
                        result += (char)(symbol - 13);
                    }
                    else if (char.IsDigit(symbol) || char.IsWhiteSpace(symbol))
                    {
                        result += symbol;
                    }
                }

                Console.WriteLine(result);
            }
        }
    }
}
