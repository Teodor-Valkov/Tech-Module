namespace _01.SinoTheWalker
{
    using System;

    class SinoTheWalker
    {
        static void Main()
        {
            string inputTime = Console.ReadLine();
            int steps = int.Parse(Console.ReadLine()) % 86400;
            int secondsPerStep = int.Parse(Console.ReadLine()) % 86400;

            if (inputTime != null)
            {
                string[] hoursMinutesSeconds = inputTime.Split(':');

                double hours = double.Parse(hoursMinutesSeconds[0]);
                double minutes= double.Parse(hoursMinutesSeconds[1]);
                double seconds= double.Parse(hoursMinutesSeconds[2]);

                double allTime = steps*secondsPerStep;

                allTime += hours*3600;
                allTime += minutes*60;
                allTime += seconds;
                        
                Console.WriteLine($@"Time Arrival: {TimeSpan.FromSeconds(allTime):hh\:mm\:ss}");
            }
        }
    }
}
