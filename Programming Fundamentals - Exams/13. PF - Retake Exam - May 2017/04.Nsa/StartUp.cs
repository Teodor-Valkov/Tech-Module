namespace _04.Nsa
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            Dictionary<string, Dictionary<string, int>> contrySpiesAndScores = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                    break;

                string[] inputArgs = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string country = inputArgs[0];
                string spy = inputArgs[1];
                int score = int.Parse(inputArgs[2]);

                if (!contrySpiesAndScores.ContainsKey(country))
                {
                    contrySpiesAndScores[country] = new Dictionary<string, int>();
                }

                contrySpiesAndScores[country][spy] = score;
            }

            contrySpiesAndScores =
                contrySpiesAndScores
                 .OrderByDescending(country => country.Value.Keys.Count)
                 .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (KeyValuePair<string, Dictionary<string, int>> pair in contrySpiesAndScores)
            {
                Console.WriteLine($"Country: {pair.Key}");

                foreach (KeyValuePair<string, int> innerPair in pair.Value.OrderByDescending(innerPair => innerPair.Value))
                {
                    Console.WriteLine($"**{innerPair.Key} : {innerPair.Value}");
                }
            }
        }
    }
}