namespace _07.PopulationCounter
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class PopulationCounter
    {
        static void Main()
        {
             Dictionary<string, Dictionary<string, long>> countryCityPopulation = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "report")
                    break;

                string[] inputArgs = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string city = inputArgs[0];
                string country = inputArgs[1];
                long population = long.Parse(inputArgs[2]);

                if (!countryCityPopulation.ContainsKey(country))
                {
                    countryCityPopulation.Add(country, new Dictionary<string, long>());
                }

                countryCityPopulation[country][city] = population;
            }

            countryCityPopulation = 
                countryCityPopulation
                .OrderByDescending(pair => pair.Value.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string, Dictionary<string, long>> pair in countryCityPopulation)
            {
                Console.WriteLine($"{pair.Key} (total population: {pair.Value.Values.Sum()})");

                foreach (KeyValuePair<string, long> innerPair in pair.Value.OrderByDescending(innerPair => innerPair.Value))
                {
                    Console.WriteLine($"=>{innerPair.Key}: {innerPair.Value}");
                }
            }
        }
    }
}