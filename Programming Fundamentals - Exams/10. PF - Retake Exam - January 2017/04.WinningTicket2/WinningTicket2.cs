namespace _04.WinningTicket2
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class WinningTicket2
    {
        static void Main()
        {
            string pattern = @"([^@$#\^]+)?([@]{6,10}|[#]{6,10}|[$]{6,10}|[\^]{6,10})([^@$#\^]+)?";

            List<string> tickets = Console.ReadLine().Trim().Split(new [] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Regex regex = new Regex(pattern);

            foreach (string ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string firstHalf = ticket.Substring(0, 10);
                string secondHalf = ticket.Substring(10);

                Match firstHalfMatch = regex.Match(firstHalf);
                Match secondHalfMatch = regex.Match(secondHalf);

                int firstHalfLength = firstHalfMatch.Groups[2].Length;
                int secondHalfLength = secondHalfMatch.Groups[2].Length;

                if (!firstHalfMatch.Success || !secondHalfMatch.Success)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    continue;
                }

                string smallerWinningTicketSymbolsCount = Math.Min(firstHalfLength, secondHalfLength) + firstHalfMatch.Groups[2].Value.First().ToString();
                if (firstHalfLength == 10 && secondHalfLength == 10)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {smallerWinningTicketSymbolsCount} Jackpot!");
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {smallerWinningTicketSymbolsCount}");
                }
            }
        }
    }
}
