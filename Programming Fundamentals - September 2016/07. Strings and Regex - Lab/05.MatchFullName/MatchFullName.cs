namespace _05.MatchFullName
{
    using System;
    using System.Text.RegularExpressions;

    internal class MatchFullNames
    {
        private static void Main()
        {
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            while (true)
            {
                string input = Console.ReadLine();

                if (input != null && input.ToLower() == "end")
                    break;

                if (input != null)
                {
                    MatchCollection matches = Regex.Matches(input, pattern);

                    foreach (Match match in matches)
                    {
                        Console.WriteLine(match);
                    }
                }
            }
        }
    }
}