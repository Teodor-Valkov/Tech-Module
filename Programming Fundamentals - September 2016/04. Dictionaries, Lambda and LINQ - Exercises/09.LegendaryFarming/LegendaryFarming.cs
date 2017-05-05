namespace _09.LegendaryFarming
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class LegendaryFarming
    {
        static void Main()
        {
            Dictionary<string, long> legendaryQuantityDictionary = new Dictionary<string, long>
            {
                ["shards"] = 0,
                ["fragments"] = 0,
                ["motes"] = 0
            };

            Dictionary<string, long> materialQuantityDictionary = new Dictionary<string, long>();

            while (legendaryQuantityDictionary["shards"] < 250 && legendaryQuantityDictionary["fragments"] < 250 && legendaryQuantityDictionary["motes"] < 250)
            {
                string input = Console.ReadLine().ToLower();
                string[] inputArgs = input.Split(' ');

                for (int i = 0; i < inputArgs.Length; i += 2)
                {
                    long currentQuantity = long.Parse(inputArgs[i]);
                    string currentMaterial = inputArgs[i + 1];

                    if (currentMaterial == "shards" || currentMaterial == "fragments" || currentMaterial == "motes")
                    {
                        legendaryQuantityDictionary[currentMaterial] += currentQuantity;
                        if (legendaryQuantityDictionary[currentMaterial] >= 250)
                            break;
                    }            
                    else
                    {
                        if (!materialQuantityDictionary.ContainsKey(currentMaterial))
                        {
                            materialQuantityDictionary.Add(currentMaterial, currentQuantity);
                        }
                        else
                        {
                            materialQuantityDictionary[currentMaterial] += currentQuantity;
                        }                                                
                    } 
                }
            }

            if (legendaryQuantityDictionary["shards"] >= 250)
            {
                Console.WriteLine("Shadowmourne obtained!");
                legendaryQuantityDictionary["shards"] -= 250;
            }
            else if (legendaryQuantityDictionary["fragments"] >= 250)
            {
                Console.WriteLine("Valanyr obtained!");
                legendaryQuantityDictionary["fragments"] -= 250;
            }
            else if (legendaryQuantityDictionary["motes"] >= 250)
            {
                Console.WriteLine("Dragonwrath obtained!");
                legendaryQuantityDictionary["motes"] -= 250;
            }

            foreach (KeyValuePair<string, long> pair in legendaryQuantityDictionary.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            { 
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            foreach (KeyValuePair<string, long> pair in materialQuantityDictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}
