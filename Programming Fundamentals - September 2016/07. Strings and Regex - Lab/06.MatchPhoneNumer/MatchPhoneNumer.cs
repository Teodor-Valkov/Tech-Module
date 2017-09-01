namespace _06.MatchPhoneNumer
{
    using System;
    using System.Text.RegularExpressions;

    class MatchPhoneNumer
    {
        static void Main()
        {
            string pattern = @"^(\s*?)(\+359(\s|\-)2\3\d{3}\3\d{4})\b";
            
            while (true)
            {
                string input = Console.ReadLine();

                if (input != null && input.ToLower() == "end")
                    break;

                Regex regex = new Regex(pattern);

                if (input != null)
                {
                    MatchCollection matches = regex.Matches(input);
                    //MatchCollection matches = Regex.Matches(input, pattern);

                    foreach (Match match in matches)
                    {
                        Console.WriteLine(match);
                    }
                }
            }
        }
    }
}
