namespace _03.Debugging_Lab
{
    using System;
    using System.Globalization;

    internal class Lab
    {
        private static void Main()
        {
            // Task 1
            MultiplyEvensByOdds();

            // Task 2
            HolidaysBetweenTwoDates();

            // Task 3
            PriceChangeAlert();
        }

        private static void MultiplyEvensByOdds()
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            int multiplyEvensByOdds = GetMultipleOfEvensAndOdds(number);

            Console.WriteLine(multiplyEvensByOdds);
        }

        private static void HolidaysBetweenTwoDates()
        {
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy", CultureInfo.InvariantCulture);
            int holidaysCount = 0;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    holidaysCount++;
                }
            }

            Console.WriteLine(holidaysCount);
        }

        private static void PriceChangeAlert()
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

        private static int GetMultipleOfEvensAndOdds(int number)
        {
            int sumOfEvens = GetSumOfEvenDigits(number);
            int sumOfOdds = GetSumOfOddDigits(number);
            int sumOfEvenAndOdds = sumOfEvens * sumOfOdds;

            return sumOfEvenAndOdds;
        }

        private static int GetSumOfEvenDigits(int number)
        {
            int sumOfEvens = 0;

            while (number > 0)
            {
                int lastDigit = number % 10;

                if (lastDigit % 2 == 0)
                {
                    sumOfEvens += lastDigit;
                }

                number /= 10;
            }

            return sumOfEvens;
        }

        private static int GetSumOfOddDigits(int number)
        {
            int sumOfOdds = 0;

            for (int i = 0; i < number.ToString().Length; i++)
            {
                int currentDigit = int.Parse(number.ToString()[i].ToString());

                if (currentDigit % 2 == 1)
                {
                    sumOfOdds += currentDigit;
                }
            }

            return sumOfOdds;
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