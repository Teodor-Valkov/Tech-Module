namespace _04.Elevator
{
    using System;

    class Elevator
    {
        static void Main()
        {
            double people = double.Parse(Console.ReadLine());
            double cabin = double.Parse(Console.ReadLine());
            double courses = Math.Ceiling(people / cabin);

            Console.WriteLine(courses);
        }
    }
}
