namespace _04.VehiclePark
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class VehiclePark
    {
        private static void Main()
        {
            List<string> availableCars = Console.ReadLine().Split(' ').ToList();
            List<string> wantedCars = new List<string>();
            int soldCars = 0;

            string order = Console.ReadLine();
            while (order != null && order.ToLower() != "end of customers!")
            {
                wantedCars.Add(order);
                order = Console.ReadLine();
            }

            for (int i = 0; i < wantedCars.Count; i++)
            {
                wantedCars[i] = wantedCars[i].Remove(1, 8);
                wantedCars[i] = wantedCars[i].Replace(" seats", "");
                wantedCars[i] = wantedCars[i].ToLower();
            }

            foreach (string car in wantedCars)
            {
                if (availableCars.Contains(car))
                {
                    availableCars.Remove(car);
                    soldCars++;

                    int price = car[0] * int.Parse(car.Substring(1));
                    Console.WriteLine($"Yes, sold for {price}$");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }

            Console.WriteLine($"Vehicles left: {string.Join(", ", availableCars)}");
            Console.WriteLine($"Vehicles sold: {soldCars}");
        }
    }
}