namespace _04.PopulationAggregation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class PopulationAggregation
    {
        private static void Main()
        {
            // Another way for removing the prohibited symbols with Regex
            //string cleaned = Regex.Replace(parameters[0], "[0-9@#$&]+", "");

            Dictionary<string, int> countriesAndCities = new Dictionary<string, int>();
            Dictionary<string, long> citiesAndPopulation = new Dictionary<string, long>();
            char[] prohibitedSymbols = { '@', '#', '$', '&' };

            string input = Console.ReadLine();
            while (input != null && input.ToLower() != "stop")
            {
                string[] parameters = input.Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

                string countryBefore = string.Empty;
                string cityBefore = string.Empty;
                long population = 0;

                if (char.IsUpper(parameters[0].First()))
                {
                    countryBefore = parameters[0];
                    cityBefore = parameters[1];
                    population = long.Parse(parameters[2]);
                }
                else
                {
                    countryBefore = parameters[1];
                    cityBefore = parameters[0];
                    population = long.Parse(parameters[2]);
                }

                string countryAfter = string.Empty;
                foreach (char symbol in countryBefore)
                {
                    if (prohibitedSymbols.Contains(symbol) || char.IsDigit(symbol))
                    {
                        continue;
                    }

                    countryAfter += symbol;
                }

                string cityAfter = string.Empty;
                foreach (char symbol in cityBefore)
                {
                    if (prohibitedSymbols.Contains(symbol) || char.IsDigit(symbol))
                    {
                        continue;
                    }

                    cityAfter += symbol;
                }

                if (!countriesAndCities.ContainsKey(countryAfter))
                {
                    countriesAndCities.Add(countryAfter, 1);
                }
                else
                {
                    countriesAndCities[countryAfter]++;
                }

                if (!citiesAndPopulation.ContainsKey(cityAfter))
                {
                    citiesAndPopulation.Add(cityAfter, population);
                }
                else
                {
                    citiesAndPopulation[cityAfter] = population;
                }

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, int> countryAndCity in countriesAndCities.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{countryAndCity.Key} -> {countryAndCity.Value}");
            }

            int counter = 0;
            foreach (KeyValuePair<string, long> cityAndPopulation in citiesAndPopulation.OrderByDescending(x => x.Value))
            {
                if (counter == 3)
                {
                    break;
                }

                counter++;
                Console.WriteLine($"{cityAndPopulation.Key} -> {cityAndPopulation.Value}");
            }
        }
    }
}