namespace _05.CalculateTriangleArea
{
    using System;

    internal class CalculateTriangleArea
    {
        private static void Main()
        {
            double side = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = GetTriangleArea(side, height);

            Console.WriteLine(area);
        }

        private static double GetTriangleArea(double side, double height)
        {
            return side * height / 2;
        }
    }
}