namespace _11.ExtractSentencesByKeyword
{
    using System;
    using System.Text.RegularExpressions;

    class ExtractSentencesByKeyword
    {
        static void Main()
        {
            string pattern = Console.ReadLine();
            string input = Console.ReadLine();

            if (input != null)
            {
                string[] inputArgs = input.Split(new [] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                Regex regex = new Regex(@"\b" + pattern + @"\b");

                foreach (string arg in inputArgs)
                {
                    Match match = regex.Match(arg);

                    if (match.Success)
                    {
                        Console.WriteLine(arg.Trim());
                    }
                }
            }
        }
    }
}
