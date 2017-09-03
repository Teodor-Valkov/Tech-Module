namespace _11.GeometryCalculator
{
    using System;

    internal class GeometryCalculator
    {
        private static void Main()
        {
            string type = Console.ReadLine();

            if (type == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double area = GetTriangleArea(side, height);

                Console.WriteLine("{0:F2}", area);
            }
            else if (type == "square")
            {
                double side = double.Parse(Console.ReadLine());
                double area = GetSquareArea(side);

                Console.WriteLine("{0:F2}", area);
            }
            else if (type == "rectangle")
            {
                double firstSide = double.Parse(Console.ReadLine());
                double secondSide = double.Parse(Console.ReadLine());
                double area = GetRectangleArea(firstSide, secondSide);

                Console.WriteLine("{0:F2}", area);
            }
            else if (type == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double area = GetCircleArea(radius);

                Console.WriteLine("{0:F2}", area);
            }
        }

        private static double GetTriangleArea(double side, double height)
        {
            return side * height / 2;
        }

        private static double GetSquareArea(double side)
        {
            return side * side;
        }

        private static double GetRectangleArea(double firstSide, double secondSide)
        {
            return firstSide * secondSide;
        }

        private static double GetCircleArea(double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }
    }
}