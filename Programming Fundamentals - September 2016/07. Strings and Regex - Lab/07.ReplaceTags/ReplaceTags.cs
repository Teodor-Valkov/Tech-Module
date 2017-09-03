namespace _07.ReplaceTags
{
    using System;
    using System.Text.RegularExpressions;

    internal class ReplaceTags
    {
        private static void Main()
        {
            string text = Console.ReadLine();

            while (text != null && text != "end")
            {
                string pattern = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
                string replace = @"[URL href=$1]$2[/URL]";

                string replaced = Regex.Replace(text, pattern, replace);

                text = Console.ReadLine();

                Console.WriteLine(replaced);
            }
        }
    }
}