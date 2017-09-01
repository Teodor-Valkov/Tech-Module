namespace _01.CountWorkingDays
{
    using System;
    using System.Linq;
    using System.Globalization;

    class CountWorkingDays
    {
        static void Main()
        {
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            long workingDays = 0;

            // The needed holidays in given year
            DateTime[] officialHollidays = 
            {
                new DateTime(2000, 01, 01), new DateTime(2000, 03, 03),
                new DateTime(2000, 05, 01), new DateTime(2000, 05, 06),
                new DateTime(2000, 05, 24), new DateTime(2000, 09, 06),
                new DateTime(2000, 09, 22), new DateTime(2000, 11, 01),
                new DateTime(2000, 12, 24), new DateTime(2000, 12, 25),
                new DateTime(2000, 12, 26)
            };

            for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
            {
                DayOfWeek currentDay = i.DayOfWeek;
                DateTime currentDate = new DateTime(2000, i.Month, i.Day);

                if (officialHollidays.Contains(currentDate))
                {
                    continue;
                }

                if (currentDay == DayOfWeek.Saturday || currentDay == DayOfWeek.Sunday)
                {
                    continue;
                }

                workingDays++;
            }

            Console.WriteLine(workingDays);
        }
    }
}
