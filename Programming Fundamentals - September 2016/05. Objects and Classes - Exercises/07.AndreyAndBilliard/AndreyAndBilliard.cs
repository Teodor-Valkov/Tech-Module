namespace _07.AndreyAndBilliard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Client
    {
        public string Name { get; set; }
        public List<string> Orders { get; set; }
        public Dictionary<string, int> OrdersQuantity { get; set; }
        public double Bill { get; set; }
    }

    internal class AndreyAndBilliard
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, double> productPriceDictionary = new Dictionary<string, double>();
            Dictionary<string, Client> namesClientsDictionary = new Dictionary<string, Client>();

            GetProductsAndPrices(n, productPriceDictionary);

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine != null && inputLine.ToLower() == "end of clients")
                    break;

                if (inputLine != null)
                {
                    string[] inputLineArgs = inputLine.Split(new[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string currentName = inputLineArgs[0];
                    string currentOrder = inputLineArgs[1];
                    int quantity = int.Parse(inputLineArgs[2]);

                    if (productPriceDictionary.ContainsKey(currentOrder))
                    {
                        Client currentClient = new Client
                        {
                            Name = currentName,
                            Orders = new List<string> { currentOrder },
                            OrdersQuantity = new Dictionary<string, int> { { currentOrder, quantity } }
                        };

                        currentClient.Bill += quantity * productPriceDictionary[currentOrder];

                        if (!namesClientsDictionary.ContainsKey(currentClient.Name))
                        {
                            namesClientsDictionary.Add(currentClient.Name, currentClient);
                        }
                        else
                        {
                            if (namesClientsDictionary[currentName].OrdersQuantity.ContainsKey(currentOrder))
                            {
                                namesClientsDictionary[currentName].OrdersQuantity[currentOrder] += quantity;
                            }
                            else
                            {
                                namesClientsDictionary[currentName].OrdersQuantity[currentOrder] = quantity;
                            }

                            namesClientsDictionary[currentName].Bill += quantity * productPriceDictionary[currentOrder];
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, Client> pair in namesClientsDictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key}");

                foreach (KeyValuePair<string, int> orderAndCount in pair.Value.OrdersQuantity)
                {
                    Console.WriteLine($"-- {orderAndCount.Key} - {orderAndCount.Value}");
                }

                Console.WriteLine($"Bill: {pair.Value.Bill:F2}");
            }

            double totalBill = namesClientsDictionary.Sum(x => x.Value.Bill);

            Console.WriteLine($"Total bill: {totalBill:F2}");
        }

        private static void GetProductsAndPrices(int n, Dictionary<string, double> productPriceDictionary)
        {
            for (int i = 0; i < n; i++)
            {
                string[] currentProductAndPriceArgs = Console.ReadLine().Split('-');

                string productName = currentProductAndPriceArgs[0];
                double productPrice = double.Parse(currentProductAndPriceArgs[1]);

                if (productPriceDictionary.ContainsKey(productName))
                {
                    productPriceDictionary[productName] = productPrice;
                }
                else
                {
                    productPriceDictionary.Add(productName, productPrice);
                }
            }
        }
    }
}