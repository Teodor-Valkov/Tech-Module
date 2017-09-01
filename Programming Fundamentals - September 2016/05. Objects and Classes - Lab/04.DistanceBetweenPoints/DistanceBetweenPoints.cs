namespace _04.DistanceBetweenPoints
{
    using System;
    using System.Linq;

    class DistanceBetweenPoints
    {
        static void Main()
        {
            Point firstPoint = Point.ReadPoint();
            Point secondPoint = Point.ReadPoint();
            double hipotenus = Point.CalcDistance(firstPoint, secondPoint);

            Console.WriteLine($"{hipotenus:F3}");
        }
    }

    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public static Point ReadPoint()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Point p = new Point()
            {
                X = numbers[0],
                Y = numbers[1]
            };

            return p;
        }

        public static double CalcDistance(Point firstPoint, Point secondPoint)
        {
            double triangleSideA = (firstPoint.X - secondPoint.X);
            double triangleSideB = (firstPoint.Y - secondPoint.Y);
            double hipotenus = Math.Sqrt(triangleSideA*triangleSideA + triangleSideB*triangleSideB);

            return hipotenus;
        }
    }
}
