namespace _10.PriceChangeAlert
{
    using System;

    internal class PriceChangeAlert
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double significanceTreshold = double.Parse(Console.ReadLine());
            double initialPrice = double.Parse(Console.ReadLine());

            for (int i = 0; i < n - 1; i++)
            {
                double nextPrice = double.Parse(Console.ReadLine());
                double difference = GetDifference(initialPrice, nextPrice);

                bool isSignificantDifference = HasSignificantDifference(difference, significanceTreshold);
                string message = GetMessage(nextPrice, initialPrice, difference, isSignificantDifference);

                initialPrice = nextPrice;

                Console.WriteLine(message);
            }
        }

        private static double GetDifference(double firstPrice, double secondPrice)
        {
            double difference = (secondPrice - firstPrice) / firstPrice;
            return difference;
        }

        private static bool HasSignificantDifference(double currentDifference, double significantDifference)
        {
            if (Math.Abs(currentDifference) >= significantDifference)
                return true;

            return false;
        }

        private static string GetMessage(double nextPrice, double initialPrice, double difference, bool isSignificantDifference)
        {
            string message = string.Empty;

            if (difference == 0)
                message = $"NO CHANGE: {nextPrice}";
            else if (!isSignificantDifference)
                message = $"MINOR CHANGE: {initialPrice} to {nextPrice} ({difference * 100:F2}%)";
            else if (isSignificantDifference && (difference > 0))
                message = $"PRICE UP: {initialPrice} to {nextPrice} ({difference * 100:F2}%)";
            else if (isSignificantDifference && (difference < 0))
                message = $"PRICE DOWN: {initialPrice} to {nextPrice} ({difference * 100:F2}%)";

            return message;
        }
    }
}