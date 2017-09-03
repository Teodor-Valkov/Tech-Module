namespace _01.DayOfWeek
{
    using System;
    using System.Globalization;

    internal class DayOfWeek
    {
        private static void Main()
        {
            // First Solution
            string dateAsString = Console.ReadLine();
            DateTime date = DateTime.ParseExact(dateAsString, "d-M-yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(date.DayOfWeek);

            // Second Solution
            //int[] dateElements = Console.ReadLine().Split('-').Select(int.Parse).ToArray();
            //DateTime date = new DateTime(dateElements[2], dateElements[1], dateElements[0]);
            //Console.WriteLine(date.DayOfWeek);
        }
    }
}