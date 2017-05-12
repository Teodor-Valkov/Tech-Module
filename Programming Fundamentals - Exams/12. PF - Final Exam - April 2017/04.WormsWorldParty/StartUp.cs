namespace _04.WormsWorldParty
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, long>> teamsWormsAndScores = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                    break;

                string[] inputArgs = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string wormName = inputArgs[0];
                string wormTeam = inputArgs[1];
                long wormScore = long.Parse(inputArgs[2]);

                if (teamsWormsAndScores.Any(pair => pair.Value.ContainsKey(wormName)))
                {
                    continue;
                }

                if (!teamsWormsAndScores.ContainsKey(wormTeam))
                {
                    teamsWormsAndScores[wormTeam] = new Dictionary<string, long>();
                }

                teamsWormsAndScores[wormTeam][wormName] = wormScore;
            }
            
            int counter = 1;
            foreach (KeyValuePair<string, Dictionary<string, long>> pair in teamsWormsAndScores)
            {
                Console.WriteLine($"{counter}. Team: {pair.Key} - {pair.Value.Values.Sum()}");

                foreach (KeyValuePair<string, long> innerPair in pair.Value.OrderByDescending(innerPair => innerPair.Value))
                {
                    Console.WriteLine($"###{innerPair.Key} : {innerPair.Value}");
                }

                counter++;
            }
        }
    }
}
