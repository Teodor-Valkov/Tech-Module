namespace _01.SoftuniAirline
{
    using System;

    class SoftuniAirline
    {
        static void Main()
        {
            int flights = int.Parse(Console.ReadLine());
            decimal overallProfit = 0;
            decimal averageProfit = 0;

            for (int currnetFlight = 0; currnetFlight < flights; currnetFlight++)
            {
                int adults = int.Parse(Console.ReadLine());
                double adultsPrice = double.Parse(Console.ReadLine());
                int youth = int.Parse(Console.ReadLine());
                double youthPrice = double.Parse(Console.ReadLine());
                double fuelPrice = double.Parse(Console.ReadLine());
                double fuelPerHour = double.Parse(Console.ReadLine());
                int duration = int.Parse(Console.ReadLine());

                decimal currentIncome = (decimal)(adults * adultsPrice) + (decimal)(youth * youthPrice);
                decimal currentExpence = (decimal)(duration * fuelPerHour * fuelPrice);

                if (currentIncome >= currentExpence)
                {
                    Console.WriteLine($"You are ahead with {currentIncome - currentExpence:F3}$.");
                    overallProfit += currentIncome - currentExpence;
                }
                else
                {
                    Console.WriteLine($"We've got to sell more tickets! We've lost {currentIncome - currentExpence:F3}$.");
                    overallProfit -= currentExpence - currentIncome;
                }
            }

            averageProfit = overallProfit / flights;

            Console.WriteLine($"Overall profit -> {overallProfit:F3}$.");
            Console.WriteLine($"Average profit -> {averageProfit:F3}$.");
        }
    }
}
