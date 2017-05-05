namespace _11.DragonArmy
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Dragon
    {
        public string DragonName { get; set; }
        public string Type { get; set; }
        public int Health { get; set; }
        public int Damage { get ; set; }
        public int Armor { get; set; }
    }

    class DragonArmy
    {
        static void Main()
        {
            int numberOfDragons = int.Parse(Console.ReadLine());
            Dictionary<string, List<Dragon>> typeDragonsDictionary = new Dictionary<string, List<Dragon>>();

            for (int i = 0; i < numberOfDragons; i++)
            {
                string input = Console.ReadLine();

                if (input != null)
                {
                    string[] inputArgs = input.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);

                    Dragon currentDragon = GetCurrentDragonStats(inputArgs);
                    AddingCurrentDragonInDictionary(typeDragonsDictionary, currentDragon);
                }
            }

            PrintingResultOnConsole(typeDragonsDictionary);
        }

        private static Dragon GetCurrentDragonStats(string[] inputArgs)
        {
            string type = inputArgs[0];
            string name = inputArgs[1];
            int damage = 45;
            int health = 250;
            int armor = 10;

            if (inputArgs[2] != "null")
                damage = int.Parse(inputArgs[2]);
            if (inputArgs[3] != "null")
                health = int.Parse(inputArgs[3]);
            if (inputArgs[4] != "null")
                armor = int.Parse(inputArgs[4]);

            Dragon currentDragon = new Dragon()
            {
                Type = type,
                DragonName = name,
                Damage = damage,
                Health = health,
                Armor = armor
            };

            return currentDragon;
        }

        private static void AddingCurrentDragonInDictionary(Dictionary<string, List<Dragon>> typeDragonsDictionary, Dragon currentDragon)
        {
            string type = currentDragon.Type;
            string name = currentDragon.DragonName;

            if (!typeDragonsDictionary.ContainsKey(type))
            {
                typeDragonsDictionary.Add(type, new List<Dragon>());
                typeDragonsDictionary[type].Add(currentDragon);
            }
            else
            {
                if (typeDragonsDictionary[type].Any(x => x.DragonName == name))
                {
                    int indexOfDragonToOverwrite = typeDragonsDictionary[type].FindIndex(x => x.DragonName == name);
                    typeDragonsDictionary[type][indexOfDragonToOverwrite] = currentDragon;
                }
                else
                {
                    typeDragonsDictionary[type].Add(currentDragon);
                }
            }
        }

        private static void PrintingResultOnConsole(Dictionary<string, List<Dragon>> typeDragonsDictionary)
        {
            //List<string> distinctedTypes = typeDragonsDictionary.Keys.Distinct().ToList();
            //foreach (string currentType in distinctedTypes)

            foreach (KeyValuePair<string, List<Dragon>> pair in typeDragonsDictionary)
            {
                string type = pair.Key;
                double averageDamage = typeDragonsDictionary[type].Select(x => x.Damage).Average();
                double averageHealth = typeDragonsDictionary[type].Select(x => x.Health).Average();
                double averageArmor = typeDragonsDictionary[type].Average(x => x.Armor);

                Console.WriteLine($"{type}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");
                foreach (Dragon currentDragon in typeDragonsDictionary[type].OrderBy(x => x.DragonName))
                {
                    Console.WriteLine($"-{currentDragon.DragonName} -> damage: {currentDragon.Damage}, health: {currentDragon.Health}, armor: {currentDragon.Armor}");
                }
            }
        }
    }
}
