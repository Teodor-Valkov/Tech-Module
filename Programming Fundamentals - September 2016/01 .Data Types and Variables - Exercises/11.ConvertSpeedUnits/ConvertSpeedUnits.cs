namespace _11.ConvertSpeedUnits
{
    using System;

    internal class ConvertSpeedUnits
    {
        private static void Main()
        {
            float meters = float.Parse(Console.ReadLine());
            float hours = float.Parse(Console.ReadLine());
            float minutes = float.Parse(Console.ReadLine());
            float seconds = float.Parse(Console.ReadLine());

            float secondsAtAll = ((hours * 60) + minutes) * 60 + seconds;
            float metersPerSecond = meters / secondsAtAll;
            Console.WriteLine($"{metersPerSecond}");

            float hoursAtAll = (seconds / 60 / 60 + (minutes / 60)) + hours;
            float kilometersPerHour = (meters / 1000) / hoursAtAll;
            Console.WriteLine($"{kilometersPerHour}");

            float milesPerHour = (meters / 1609) / hoursAtAll;
            Console.WriteLine($"{milesPerHour}");
        }
    }
}