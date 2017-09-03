namespace _01.SplinterTrip
{
    using System;

    internal class StartUp
    {
        private static void Main()
        {
            double distanceInMiles = double.Parse(Console.ReadLine());
            double fuelCapacity = double.Parse(Console.ReadLine());
            double milesWithHeavyWinds = double.Parse(Console.ReadLine());

            double milesWithoutHeavyWinds = distanceInMiles - milesWithHeavyWinds;

            double consumptionWithoutWinds = milesWithoutHeavyWinds * 25;
            double consumptionWithWinds = milesWithHeavyWinds * 25 * 1.5;
            double fuelConsumption = consumptionWithoutWinds + consumptionWithWinds;

            double spareFuel = fuelConsumption * 0.05;
            fuelConsumption += spareFuel;

            double result = fuelCapacity - fuelConsumption;

            if (result < 0)
            {
                Console.WriteLine($"Fuel needed: {fuelConsumption:F2}L");
                Console.WriteLine($"We need {Math.Abs(result):F2}L more fuel.");
            }
            else
            {
                Console.WriteLine($"Fuel needed: {fuelConsumption:F2}L");
                Console.WriteLine($"Enough with {Math.Abs(result):F2}L to spare!");
            }
        }
    }
}