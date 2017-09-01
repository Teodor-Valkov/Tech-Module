namespace _04.PokemonEvolution
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, List<KeyValuePair<string, int>>> pokemons = new Dictionary<string, List<KeyValuePair<string, int>>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "wubbalubbadubdub")
            {
                string[] inputArgs = input.Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                string name;

                if (inputArgs.Length == 1)
                {
                    name = inputArgs[0];

                    if (pokemons.ContainsKey(name))
                    {
                        Console.WriteLine($"# {name}");
                        foreach (KeyValuePair<string, int> evolutionAndLevel in pokemons[name])
                        {
                            Console.WriteLine($"{evolutionAndLevel.Key} <-> {evolutionAndLevel.Value}");
                        }
                    }

                    continue;
                }

                name = inputArgs[0];
                string evolution = inputArgs[1];
                int level = int.Parse(inputArgs[2]);

                if (!pokemons.ContainsKey(name))
                {
                    pokemons[name] = new List<KeyValuePair<string, int>>();
                }

                pokemons[name].Add(new KeyValuePair<string, int>(evolution, level));
            }

            foreach (KeyValuePair<string, List<KeyValuePair<string, int>>> pokemon in pokemons)
            {
                Console.WriteLine($"# {pokemon.Key}");
                foreach (KeyValuePair<string, int> evolutionAndLevel in pokemon.Value.OrderByDescending(evolution => evolution.Value))
                {
                    Console.WriteLine($"{evolutionAndLevel.Key} <-> {evolutionAndLevel.Value}");
                }
            }
        }
    }
}
