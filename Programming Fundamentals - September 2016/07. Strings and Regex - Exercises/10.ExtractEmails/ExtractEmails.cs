namespace _10.ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    internal class ExtractEmails
    {
        private static void Main()
        {
            //Examples of valid emails: info @softuni-bulgaria.org, kiki @hotmail.co.uk, no - reply@github.com, s.peterson @mail.uu.net, info - bg@software - university.software.academy.
            //Examples of invalid emails: --123@gmail.com, …@mail.bg, .info @info.info, _steve @yahoo.cn, mike @helloworld, mike@.unknown.soft., s.johnson @invalid-

            //However with this regex if a valid email is in the beggining of the sentence it won't be caught - SOLVED => just add (\s|^) in the beginning

            string input = Console.ReadLine();

            string pattern = @"((?<=\s|^)[a-zA-Z0-9]+([\.|_\-])?[a-zA-Z0-9]+@[a-zA-Z]+([\.\-][a-zA-Z]+)*(\.[a-zA-Z]+))";

            Regex regex = new Regex(pattern);

            if (input != null)
            {
                MatchCollection matches = regex.Matches(input);

                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
    }
}