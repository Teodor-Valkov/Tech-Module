namespace _04.HornetArmada
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class HornetArmada
    {
        static void Main()
        {
            Dictionary<string, int> legionsWithActivity = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, long>> legionsWithSoldiers = new Dictionary<string, Dictionary<string, long>>(); 

            int numberOfLegions = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < numberOfLegions; i++)
            {
                string input = Console.ReadLine();

                if (input != null)
                {
                    string[] inputArgs = input.Split(new[] {"=", "->", ":", " "}, StringSplitOptions.RemoveEmptyEntries);

                    int lastActivity = int.Parse(inputArgs[0]);
                    string legionName = inputArgs[1];
                    string soldierType = inputArgs[2];
                    int soldiersCount = int.Parse(inputArgs[3]);

                    char[] forbiddenSymbols = {'=', '-', '>', ':', ' '};
                    if (legionName.Any(symbol => forbiddenSymbols.Contains(symbol)) || soldierType.Any(symbol => forbiddenSymbols.Contains(symbol)))
                    {
                        continue;
                    }

                    if (!legionsWithActivity.ContainsKey(legionName))
                    {
                        legionsWithActivity.Add(legionName, lastActivity);
                    }
                    else
                    {
                        if (legionsWithActivity[legionName] < lastActivity)
                        {
                            legionsWithActivity[legionName] = lastActivity;
                        }
                    }

                    if (!legionsWithSoldiers.ContainsKey(legionName))
                    {
                        Dictionary<string, long> soldiersWithCount = new Dictionary<string, long>();
                        soldiersWithCount.Add(soldierType, soldiersCount);

                        legionsWithSoldiers.Add(legionName, soldiersWithCount);
                    }
                    else
                    {
                        if (!legionsWithSoldiers[legionName].ContainsKey(soldierType))
                        {
                            legionsWithSoldiers[legionName].Add(soldierType, soldiersCount);
                        }
                        else
                        {
                            legionsWithSoldiers[legionName][soldierType] += soldiersCount;
                        }
                    }
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

                foreach (KeyValuePair<string, Dictionary<string, long>> pair in legionsWithSoldiers)
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
