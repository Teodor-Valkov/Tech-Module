namespace _01.Pokemon
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int pokemonPower = int.Parse(Console.ReadLine());
            int pokemonDistance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int targets = 0;
            int pokemonInitialPower = pokemonPower;

            while (pokemonPower >= pokemonDistance)
            {
                pokemonPower -= pokemonDistance;
                targets++;

                if (pokemonPower == pokemonInitialPower / 2)
                {
                    if (pokemonPower >= exhaustionFactor && exhaustionFactor > 0)
                    {
                        pokemonPower /= exhaustionFactor;
                    }
                }
            }

            Console.WriteLine(pokemonPower);
            Console.WriteLine(targets);
        }
    }
}