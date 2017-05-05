namespace _04.SoftuniCoffeeSupplies
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class SoftuniCoffeeSupplies
    {
        static void Main()
        {
            string[] separators = Console.ReadLine().Split(' ');
            string currentInfoLine = Console.ReadLine();

            Dictionary<string, string> personAndCoffee = new Dictionary<string, string>();
            Dictionary<string, int> coffeeTypeAndQuantity = new Dictionary<string, int>();

            while (currentInfoLine != null && currentInfoLine.ToLower() != "end of info")
            {
                string[] currentInfoLineSeparated = currentInfoLine.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                string personName = string.Empty;
                string coffeeType = string.Empty;
                int quantity = 0;

                if (currentInfoLine.Contains(separators[0]))
                {
                    personName = currentInfoLineSeparated[0];
                    coffeeType = currentInfoLineSeparated[1];
                    personAndCoffee.Add(personName, coffeeType);

                    if (!coffeeTypeAndQuantity.ContainsKey(coffeeType))
                    {
                        coffeeTypeAndQuantity.Add(coffeeType, 0);
                    }                        
                }

                if (currentInfoLine.Contains(separators[1]))
                {
                    if (currentInfoLineSeparated.Length == 3)
                    {
                        quantity = int.Parse(currentInfoLineSeparated[2]);
                    }
                    else
                    {
                        coffeeType = currentInfoLineSeparated[0];
                        quantity = int.Parse(currentInfoLineSeparated[1]);
                    }

                    if (coffeeTypeAndQuantity.ContainsKey(coffeeType))
                    {
                        coffeeTypeAndQuantity[coffeeType] += quantity;
                    }
                    else
                    {
                        coffeeTypeAndQuantity.Add(coffeeType, quantity);
                    }
                }

                currentInfoLine = Console.ReadLine();
            }

            foreach (KeyValuePair<string, int> pair in coffeeTypeAndQuantity)
            {
                if (pair.Value <= 0)
                {
                    Console.WriteLine($"Out of {pair.Key}");
                }
            }

            string orders = Console.ReadLine();
            List<string> oufOfCoffeeList = new List<string>();

            while (orders != null && orders.ToLower() != "end of week")
            {
                string[] tokens = orders.Split(' ');
                string person = tokens[0];
                int cups = int.Parse(tokens[1]);
                
                string personFavouriteCoffe = personAndCoffee[person];
                coffeeTypeAndQuantity[personFavouriteCoffe] -= cups;

                if (coffeeTypeAndQuantity[personFavouriteCoffe] <= 0)
                {
                    oufOfCoffeeList.Add(personFavouriteCoffe);
                }
    
                orders = Console.ReadLine();
            }

            foreach (string coffeeEnded in oufOfCoffeeList)
            {
                Console.WriteLine($"Out of {coffeeEnded}");
            }

            Console.WriteLine("Coffee Left:");
            foreach (KeyValuePair<string, int> pair in coffeeTypeAndQuantity.OrderByDescending(x => x.Value))
            {
                string currentFavouriteCoffeeTypeLeft = pair.Key;
                if (coffeeTypeAndQuantity[currentFavouriteCoffeeTypeLeft] > 0)
                {
                    Console.WriteLine($"{pair.Key} {pair.Value}");
                }                    
            }

            Console.WriteLine("For:");
            foreach (KeyValuePair<string, string> pair in personAndCoffee.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                string currentFavouriteCoffeeTypeLeft = pair.Value;
                if (coffeeTypeAndQuantity[currentFavouriteCoffeeTypeLeft] <= 0)
                {
                    continue;
                }

                Console.WriteLine($"{pair.Key} {pair.Value}");
            }
        }
    }
}
