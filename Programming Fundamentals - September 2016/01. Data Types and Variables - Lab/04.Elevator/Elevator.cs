namespace _04.Elevator
{
    using System;

    internal class Elevator
    {
        private static void Main()
        {
            double people = double.Parse(Console.ReadLine());
            double cabin = double.Parse(Console.ReadLine());
            double courses = Math.Ceiling(people / cabin);

            Console.WriteLine(courses);
        }
    }
}