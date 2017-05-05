namespace _04.HornetArmadaRegex
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class HornetArmadaRegex
    {
        static void Main()
        {
            Dictionary<string, int> legionsWithActivity = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, long>> legionsWithSoldiers = new Dictionary<string, Dictionary<string, long>>();

            int n = int.Parse(Console.ReadLine());

            string pattern = @"(\d+)\s\=\s(.+)\s\-\>\s(.+)\:(\d+)";
            Regex inputRegex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                Match inputMatch = inputRegex.Match(Console.ReadLine());

                int lastActivity = int.Parse(inputMatch.Groups[1].Value);
                string legionName = inputMatch.Groups[2].Value;
                string soldierType = inputMatch.Groups[3].Value;
                int soldierCount = int.Parse(inputMatch.Groups[4].Value);

                if (!legionsWithActivity.ContainsKey(legionName))
                {
                    legionsWithActivity.Add(legionName, lastActivity);
                    legionsWithSoldiers.Add(legionName, new Dictionary<string, long>());
                }

                if (lastActivity > legionsWithActivity[legionName])
                {
                    legionsWithActivity[legionName] = lastActivity;
                }

                if (!legionsWithSoldiers[legionName].ContainsKey(soldierType))
                {
                    legionsWithSoldiers[legionName].Add(soldierType, soldierCount);
                }
                else
                {
                    legionsWithSoldiers[legionName][soldierType] += soldierCount;                
                }
            }

            string[] resultArgs = Console.ReadLine().Split('\\');

            if (resultArgs.Length == 1)
            {
                string soldierType = resultArgs[0];

                legionsWithActivity = legionsWithActivity
                    .OrderByDescending(pair => pair.Value)
                    .ToDictionary(pair => pair.Key, pair => pair.Value);

                foreach (KeyValuePair<string, int> pair in legionsWithActivity)
                {
                    if (legionsWithSoldiers[pair.Key].ContainsKey(soldierType))
                    {
                        Console.WriteLine($"{pair.Value} : {pair.Key}");
                    }
                }
            }
            else
            {
                int activity = int.Parse(resultArgs[0]);
                string soldierType = resultArgs[1];

                legionsWithSoldiers = legionsWithSoldiers
                   .Where(legion => legion.Value.ContainsKey(soldierType))
                   .OrderByDescending(legion => legion.Value[soldierType])
                   .ToDictionary(pair => pair.Key, pair => pair.Value);

                foreach (KeyValuePair<string, Dictionary< string, long>> pair in legionsWithSoldiers)
                {
                    if (legionsWithActivity[pair.Key] < activity)
                    {
                        Console.WriteLine($"{pair.Key} -> {legionsWithSoldiers[pair.Key][soldierType]}");
                    }
                }
            }
        }
    }
}
