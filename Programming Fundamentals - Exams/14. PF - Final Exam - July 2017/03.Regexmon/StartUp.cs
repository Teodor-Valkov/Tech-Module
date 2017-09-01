namespace _03.Regexmon
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<string> result = new List<string>();

            string didiPattern = "([^a-zA-Z-]+)";
            Regex didiRegex = new Regex(didiPattern);

            string bojoPattern = "([a-zA-Z]+-[a-zA-Z]+)";
            Regex bojoRegex = new Regex(bojoPattern);

            bool didiTurn = true;

            while (true)
            {
                if (didiTurn)
                {
                    if (didiRegex.IsMatch(input))
                    {
                        Match didiMatch = didiRegex.Match(input);

                        input = input.Remove(0, didiMatch.Index + didiMatch.Length);

                        result.Add(didiMatch.ToString());
                    }
                    else
                    {
                        break;
                    }

                    didiTurn = !didiTurn;
                }

                if (!didiTurn)
                {
                    if (bojoRegex.IsMatch(input))
                    {
                        Match bojoMatch = bojoRegex.Match(input);

                        input = input.Remove(0, bojoMatch.Index + bojoMatch.Length);

                        result.Add(bojoMatch.ToString());
                    }
                    else
                    {
                        break;
                    }

                    didiTurn = !didiTurn;
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
