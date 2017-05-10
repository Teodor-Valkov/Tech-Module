namespace _08.Advanced_Collections_Lab
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Lab
    {
        static void Main()
        {
            // Task 1
            AverageStudentGrades();

            // Task 2
            CitiesByContinentAndCountry();

            // Task 3
            RecordUniqueNames();

            // Task 4
            GroupContinentsCountriesAndCities();
        }

        private static void AverageStudentGrades()
        {
            Dictionary<string, List<double>> studentsAndGrades = new Dictionary<string, List<double>>();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();

                if (input != null)
                {
                    string[] inputArgs = input.Split();
                    string name = inputArgs[0];
                    double grade = double.Parse(inputArgs[1]);

                    if (!studentsAndGrades.ContainsKey(name))
                    {
                        studentsAndGrades[name] = new List<double>();
                    }

                    studentsAndGrades[name].Add(grade);
                }
            }

            foreach (KeyValuePair<string, List<double>> pair in studentsAndGrades)
            {
                Console.WriteLine($"{pair.Key} -> {string.Join(" ", pair.Value.Select(grade => string.Format($"{grade:F2}")))} (avg: {pair.Value.Average():F2})");
            }

            //studentsAndGrades
            //    .ToList()
            //    .ForEach(pair => 
            //    Console.WriteLine($"{pair.Key} -> {string.Join(" ", pair.Value.Select(grade => string.Format($"{grade:F2}")))} (avg: {pair.Value.Average():F2})"));
        }

        private static void CitiesByContinentAndCountry()
        {
            Dictionary<string, Dictionary<string, List<string>>> continentCountryAndCities = new Dictionary<string, Dictionary<string, List<string>>>();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();

                if (input != null)
                {
                    string[] inputArgs = input.Split();
                    string continent = inputArgs[0];
                    string country = inputArgs[1];
                    string city = inputArgs[2];
                   
                    if (!continentCountryAndCities.ContainsKey(continent))
                    {
                        continentCountryAndCities[continent] = new Dictionary<string, List<string>>();
                        continentCountryAndCities[continent].Add(country, new List<string>());
                    }

                    if (!continentCountryAndCities[continent].ContainsKey(country))
                    {
                        continentCountryAndCities[continent].Add(country, new List<string>());
                    }

                    continentCountryAndCities[continent][country].Add(city);
                }
            }

            foreach (KeyValuePair<string, Dictionary<string, List<string>>> pair in continentCountryAndCities)
            {
                Console.WriteLine($"{pair.Key}:");

                foreach (KeyValuePair<string, List<string>> innerPair in pair.Value)
                {
                    Console.WriteLine($"   {innerPair.Key} -> {string.Join(", ", innerPair.Value)}");
                }
            }

            // Wrong printing on cities list...
            //
            //    continentCountryAndCities
            //        .ToList()
            //        .ForEach(
            //            pair =>
            //                Console.WriteLine($"{pair.Key}:\n   {string.Join("\n   ", pair.Value.Keys)} -> {string.Join(", ", pair.Value.Values.SelectMany(pair2 => pair2))}"));
        }

        private static void RecordUniqueNames()
        {
            HashSet<string> setWithUniqueNames = new HashSet<string>();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string name = Console.ReadLine();
                setWithUniqueNames.Add(name);
            }

            Console.WriteLine(string.Join("\n", setWithUniqueNames));
        }

        private static void GroupContinentsCountriesAndCities()
        {
            SortedDictionary<string, SortedDictionary<string, SortedSet<string>>> continentCountryAndCities = new SortedDictionary<string, SortedDictionary<string, SortedSet<string>>>();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();

                if (input != null)
                {
                    string[] inputArgs = input.Split();
                    string continent = inputArgs[0];
                    string country = inputArgs[1];
                    string city = inputArgs[2];

                    if (!continentCountryAndCities.ContainsKey(continent))
                    {
                        continentCountryAndCities[continent] = new SortedDictionary<string, SortedSet<string>>();
                        continentCountryAndCities[continent].Add(country, new SortedSet<string>());
                    }

                    if (!continentCountryAndCities[continent].ContainsKey(country))
                    {
                        continentCountryAndCities[continent].Add(country, new SortedSet<string>());
                    }

                    continentCountryAndCities[continent][country].Add(city);
                }
            }

            foreach (KeyValuePair<string, SortedDictionary<string, SortedSet<string>>> pair in continentCountryAndCities)
            {
                Console.WriteLine($"{pair.Key}:");

                foreach (KeyValuePair<string, SortedSet<string>> innerPair in pair.Value)
                {
                    Console.WriteLine($"   {innerPair.Key} -> {string.Join(", ", innerPair.Value)}");
                }
            }
        }
    }
}
