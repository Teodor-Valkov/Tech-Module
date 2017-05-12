namespace _09.LegendaryFarming
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class LegendaryFarming
    {
        static void Main()
        {
            Dictionary<string, long> itemQuantity = new Dictionary<string, long>
            {
                ["shards"] = 0,
                ["fragments"] = 0,
                ["motes"] = 0
            };

            SortedDictionary<string, long> materialQuantity = new SortedDictionary<string, long>();

            while (itemQuantity["shards"] < 250 && itemQuantity["fragments"] < 250 && itemQuantity["motes"] < 250)
            {
                string input = Console.ReadLine().ToLower();

                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < inputArgs.Length; i += 2)
                {
                    long quantity = long.Parse(inputArgs[i]);
                    string material = inputArgs[i + 1];

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        itemQuantity[material] += quantity;

                        if (itemQuantity[material] >= 250)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (!materialQuantity.ContainsKey(material))
                        {
                            materialQuantity[material] = 0;
                        }

                        materialQuantity[material] += quantity;
                    }
                }
            }

            if (itemQuantity["shards"] >= 250)
            {
                Console.WriteLine("Shadowmourne obtained!");
                itemQuantity["shards"] -= 250;
            }
            else if (itemQuantity["fragments"] >= 250)
            {
                Console.WriteLine("Valanyr obtained!");
                itemQuantity["fragments"] -= 250;
            }
            else if (itemQuantity["motes"] >= 250)
            {
                Console.WriteLine("Dragonwrath obtained!");
                itemQuantity["motes"] -= 250;
            }

            itemQuantity =
                itemQuantity
                 .OrderByDescending(pair => pair.Value)
                 .ThenBy(pair => pair.Key)
                 .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (KeyValuePair<string, long> pair in itemQuantity)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            foreach (KeyValuePair<string, long> pair in materialQuantity)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}
