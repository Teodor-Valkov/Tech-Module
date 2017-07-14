namespace _02.PokemonDontGo
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            List<int> pokemons = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int sum = 0;

            while (pokemons.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int pokemon = 0;

                if (index >= 0 && index < pokemons.Count)
                {
                    pokemon = pokemons[index];
                    pokemons.RemoveAt(index);
                }
                else if (index < 0)
                {
                    index = 0;
                    pokemon = pokemons[index];
                    pokemons.RemoveAt(index);

                    int temp = pokemons.Last();
                    pokemons.Insert(0, temp);
                }
                else if (index >= pokemons.Count)
                {
                    index = pokemons.Count - 1;
                    pokemon = pokemons[index];
                    pokemons.RemoveAt(index);

                    int temp = pokemons.First();
                    pokemons.Add(temp);
                }
                
                for (int i = 0; i < pokemons.Count; i++)
                {
                    if (pokemons[i] <= pokemon)
                    {
                        pokemons[i] += pokemon;
                    }
                    else if (pokemons[i] > pokemon)
                    {
                        pokemons[i] -= pokemon;
                    }
                }

                sum += pokemon;
            }

            Console.WriteLine(sum);
        }
    }
}
