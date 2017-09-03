namespace _01.SoftuniAirlineClass
{
    using System;

    internal class Flight
    {
        public int Adults { get; set; }
        public double AdultsPrice { get; set; }
        public int Youth { get; set; }
        public double YouthPrice { get; set; }
        public double FuelPrice { get; set; }
        public double FuelPerHour { get; set; }
        public int Duration { get; set; }

        //public decimal CurrentIncome => (decimal)(Adults * AdultsPrice) + (decimal)(Youth * YouthPrice);
        public decimal CurrentIncome
        {
            get
            {
                return (decimal)(Adults * AdultsPrice) + (decimal)(Youth * YouthPrice);
            }
        }

        //public decimal currentExpense => (decimal)(Duration * FuelPerHour * FuelPrice);
        public decimal CurrentExpense
        {
            get
            {
                return (decimal)(Duration * FuelPerHour * FuelPrice);
            }
        }
    }

    internal class SoftuniAirlineClass
    {
        private static void Main()
        {
            int flights = int.Parse(Console.ReadLine());
            decimal overallProfit = 0;
            decimal averageProfit = 0;

            for (int currFlight = 0; currFlight < flights; currFlight++)
            {
                Flight currentFlight = new Flight
                {
                    Adults = int.Parse(Console.ReadLine()),
                    AdultsPrice = double.Parse(Console.ReadLine()),
                    Youth = int.Parse(Console.ReadLine()),
                    YouthPrice = double.Parse(Console.ReadLine()),
                    FuelPrice = double.Parse(Console.ReadLine()),
                    FuelPerHour = double.Parse(Console.ReadLine()),
                    Duration = int.Parse(Console.ReadLine())
                };

                if (currentFlight.CurrentIncome >= currentFlight.CurrentExpense)
                {
                    Console.WriteLine($"You are ahead with {currentFlight.CurrentIncome - currentFlight.CurrentExpense:F3}$.");
                    overallProfit += currentFlight.CurrentIncome - currentFlight.CurrentExpense;
                }
                else
                {
                    Console.WriteLine($"We've got to sell more tickets! We've lost {currentFlight.CurrentIncome - currentFlight.CurrentExpense:F3}$.");
                    overallProfit -= currentFlight.CurrentExpense - currentFlight.CurrentIncome;
                }
            }

            averageProfit = overallProfit / flights;

            Console.WriteLine($"Overall profit -> {overallProfit:F3}$.");
            Console.WriteLine($"Average profit -> {averageProfit:F3}$.");
        }
    }
}