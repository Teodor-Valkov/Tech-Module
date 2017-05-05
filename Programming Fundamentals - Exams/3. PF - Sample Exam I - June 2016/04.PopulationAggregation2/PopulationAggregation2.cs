namespace _04.PopulationAggregation2
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class PopulationAggregation2
    {
        static void Main()
        {
            // Another way for removing the prohibited symbols with Regex
            //string cleaned = Regex.Replace(parameters[0], "[0-9@#$&]+", "");

            Dictionary<string, int> countriesAndCities = new Dictionary<string, int>();
            Dictionary<string, long> citiesAndPopulation = new Dictionary<string, long>();

            string input = Console.ReadLine();
            while (input != null && input.ToLower() != "stop")
            {
                string[] parameters = input.Split(new [] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

                string country = string.Empty;
                string city = string.Empty;
                long population = 0;

                if (parameters[0].First() == char.ToUpper(parameters[0].First()))
                {
                    country = parameters[0];
                    city = parameters[1];
                    population = long.Parse(parameters[2]);
                }
                else
                {
                    country = parameters[1];
                    city = parameters[0];
                    population = long.Parse(parameters[2]);
                }

                country = country.Replace("@", string.Empty);
                country = country.Replace("#", string.Empty);
                country = country.Replace("$", string.Empty);
                country = country.Replace("&", string.Empty);
                city = city.Replace("@", string.Empty);
                city = city.Replace("#", string.Empty);
                city = city.Replace("$", string.Empty);
                city = city.Replace("&", string.Empty);

                for (int i = 0; i <= 9; i++)
                {
                    country = country.Replace(i.ToString(), string.Empty);
                    city = city.Replace(i.ToString(), string.Empty);    
                }

                if (!countriesAndCities.ContainsKey(country))
                {
                    countriesAndCities.Add(country, 1);
                }
                else
                {
                    countriesAndCities[country]++;
                }

                if (!citiesAndPopulation.ContainsKey(city))
                {
                    citiesAndPopulation.Add(city, population);
                }
                else
                {
                    citiesAndPopulation[city] = population;
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
