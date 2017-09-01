namespace _10.SrubskoUnleashed
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class SrubskoUnleashed
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, double>> venueSingersMoney = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                    break;

                string venue = string.Empty;
                string singer = string.Empty;
                double ticketPrice = 0;
                double ticketCount = 0;

                string pattern = "(.+)\\s@(.+)\\s(\\d+)\\s(\\d+)";
                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);
                if (match.Success)
                {
                    singer = match.Groups[1].Value;
                    venue = match.Groups[2].Value;
                    ticketPrice = int.Parse(match.Groups[3].Value);
                    ticketCount = int.Parse(match.Groups[4].Value);
                }
                else
                {
                    continue;
                }

                if (!venueSingersMoney.ContainsKey(venue))
                {
                    venueSingersMoney[venue] = new Dictionary<string, double>();
                }

                if (!venueSingersMoney[venue].ContainsKey(singer))
                {
                    venueSingersMoney[venue][singer] = 0;
                }

                venueSingersMoney[venue][singer] += ticketPrice * ticketCount;
            }

            foreach (KeyValuePair<string, Dictionary<string, double>> pair in venueSingersMoney)
            {
                Console.WriteLine(pair.Key);

                foreach (KeyValuePair<string, double> innePair in pair.Value.OrderByDescending(innerPair => innerPair.Value))
                {
                    Console.WriteLine($"#  {innePair.Key} -> {innePair.Value}");
                }
            }
        }
    }
}
