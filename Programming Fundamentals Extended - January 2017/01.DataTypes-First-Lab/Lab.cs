namespace _01.DataTypes_First_Lab
{
    using System;

    class Lab
    {
        static void Main()
        {
            // Task 1
            TimeSinceBirthday();

            // Task 2
            CirclePerimeter();

            // Task 3
            ExactProductOfRealNumbers();

            // Task 4
            Transport();
        }

        private static void TimeSinceBirthday()
        {
            byte years = byte.Parse(Console.ReadLine());
            int days = years * 365;
            long hours = days * 24;
            long minutes = hours * 60;

            Console.WriteLine($"{years} years = {days} days = {hours} hours = {minutes} minutes");
        }

        private static void CirclePerimeter()
        {
            double radius = double.Parse(Console.ReadLine());
            Console.WriteLine($"{2 * Math.PI * radius:F12}");
        }

        private static void ExactProductOfRealNumbers()
        {
            int n = int.Parse(Console.ReadLine());
            decimal sum = 1m;

            for (int i = 0; i < n; i++)
            {
                sum *= decimal.Parse(Console.ReadLine());
            }

            Console.WriteLine(sum);
        }

        private static void Transport()
        {
            double people = double.Parse(Console.ReadLine());
            double capacity = 4 + 8 + 12;
            double courses = Math.Ceiling(people / capacity);

            Console.WriteLine(courses);
        }
    }
}
