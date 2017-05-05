namespace _03.MinerTask
{
    using System;
    using System.Collections.Generic;

    class MinerTask
    {
        static void Main()
        {
            Dictionary<string, long> resourceAndQuantity = new Dictionary<string, long>();
            
            while (true)
            {
                string resource = Console.ReadLine();

                if (resource != null && resource.ToLower() == "stop")
                    break;

                int quantity = int.Parse(Console.ReadLine());

                if (resourceAndQuantity.ContainsKey(resource))
                {
                    resourceAndQuantity[resource] += quantity;
                }
                else
                {
                    resourceAndQuantity.Add(resource, quantity);
                }
            }

            foreach (KeyValuePair<string, long> pair in resourceAndQuantity)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
