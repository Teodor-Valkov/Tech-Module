namespace _07.SalesReport
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
    }

    internal class SalesReport
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Sale> sales = new List<Sale>();

            for (int i = 0; i < n; i++)
            {
                Sale currentSale = ReadSale();
                sales.Add(currentSale);
            }

            List<string> towns = sales.Select(x => x.Town).OrderBy(x => x).Distinct().ToList();

            foreach (string currentTown in towns)
            {
                double saleForTown = sales.Where(x => x.Town == currentTown).Sum(x => x.Price * x.Quantity);
                // saleForTown = sales.Where(x => x.town == currentTown).Select(x => x.price * x.quantity).Sum();

                Console.WriteLine($"{currentTown} -> {saleForTown:F2}");
            }
        }

        private static Sale ReadSale()
        {
            string[] input = Console.ReadLine().Split(' ');

            Sale itemsFromInput = new Sale()
            {
                Town = input[0],
                Product = input[1],
                Price = double.Parse(input[2]),
                Quantity = double.Parse(input[3])
            };

            return itemsFromInput;
        }
    }
}