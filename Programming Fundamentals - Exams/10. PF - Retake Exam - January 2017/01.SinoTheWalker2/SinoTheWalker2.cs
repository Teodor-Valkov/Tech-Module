namespace _01.SinoTheWalker2
{
    using System;
    using System.Globalization;

    internal class SinoTheWalker2
    {
        private static void Main()
        {
            string inputTime = Console.ReadLine();
            long steps = long.Parse(Console.ReadLine());
            long secondsPerStep = long.Parse(Console.ReadLine());

            long allTime = steps * secondsPerStep;
            long seconds = allTime % 86400;

            DateTime timeSinoLeaves = DateTime.ParseExact(inputTime, "HH:mm:ss", CultureInfo.CurrentCulture);
            DateTime timeSinoArrives = timeSinoLeaves.AddSeconds(seconds);

            Console.WriteLine($"Time Arrival: {timeSinoArrives:HH:mm:ss}");
        }
    }
}