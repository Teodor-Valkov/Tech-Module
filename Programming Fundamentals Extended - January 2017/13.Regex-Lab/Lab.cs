namespace _13.Regex_Lab
{
    using System;
    using System.Text.RegularExpressions;

    internal class Lab
    {
        private static void Main()
        {
            // Task 1
            ReplaceTag();
        }

        private static void ReplaceTag()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                    break;

                string pattern = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
                string replace = @"[URL href=$1]$2[/URL]";

                string replaced = Regex.Replace(input, pattern, replace);

                Console.WriteLine(replaced);
            }
        }
    }
}