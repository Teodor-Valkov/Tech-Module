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

            string input = Console.ReadLine();

            while (input != null && input.ToLower() != "report")
            {
                string[] parameters = input.Split(new [] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string city = parameters[0]; 
                string country = parameters[1];
                long population = long.Parse(parameters[2]);

                if (!countryCityPopulation.ContainsKey(country))               
                {
                    countryCityPopulation.Add(country, new Dictionary<string, long>());
                    countryCityPopulation[country].Add(city, population);
                }
                else
                {
                    countryCityPopulation[country].Add(city, population);
                }

                input = Console.ReadLine();
            }

            // Sorting the dictionary by the sum of each country total population in descending order
            countryCityPopulation = countryCityPopulation.OrderByDescending(x => x.Value.Values.Sum()).ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string, Dictionary<string, long>> pair in countryCityPopulation)
            {
                string currentCountry = pair.Key;

                Console.WriteLine($"{currentCountry} (total population: {countryCityPopulation[currentCountry].Values.Sum()})");
                foreach (KeyValuePair<string, long> cityPopulation in countryCityPopulation[currentCountry].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{cityPopulation.Key}: {cityPopulation.Value}");                    
                }
            }
        }
    }
}