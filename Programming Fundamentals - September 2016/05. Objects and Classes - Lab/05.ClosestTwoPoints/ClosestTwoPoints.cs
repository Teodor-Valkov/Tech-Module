namespace _05.ClosestTwoPoints
{
    using System;
    using System.Linq;

    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public override string ToString()
        {
            return "Point(" + X + ", " + Y + ")";
        }
    }

    class ClosestTwoPointsAndDistance
    {
        public Point First { get; set; }
        public Point Second { get; set; }
        public double Distance { get; set; }
    }

    class NearestTwoPoints
    {
        static void Main()
        {
            Point[] points = ReadArrayOfPoints();

            ClosestTwoPointsAndDistance closestTwoPointsAndDistance = FindClosestTwoPoints(points);

            Console.WriteLine($"{closestTwoPointsAndDistance.Distance:F3}");
            Console.WriteLine(closestTwoPointsAndDistance.First);
            Console.WriteLine(closestTwoPointsAndDistance.Second);
        }
    
        public static Point[] ReadArrayOfPoints()
        {
            int n = int.Parse(Console.ReadLine());

            Point[] points = new Point[n];

            for (int i = 0; i < n; i++)
            {
                int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                points[i] = new Point()
                {
                    X = nums[0],
                    Y = nums[1]
                };
            }

            return points;
        }

        public static ClosestTwoPointsAndDistance FindClosestTwoPoints(Point[] points)
        {
            ClosestTwoPointsAndDistance closestTwoAndDistance = new ClosestTwoPointsAndDistance();
            double minimalDistance = double.MaxValue;

            for (int first = 0; first < points.Length; first++)
            {
                for (int second = first + 1; second < points.Length; second++)
                {
                    Point p1 = points[first];
                    Point p2 = points[second];
                    double currentDistance = CalcDistance(p1, p2);

                    if (currentDistance < minimalDistance)
                    {
                        minimalDistance = currentDistance;
                        closestTwoAndDistance = new ClosestTwoPointsAndDistance()
                        {
                            First = p1,
                            Second = p2,
                            Distance = currentDistance
                        } ;
                    }
                }
            }

            return closestTwoAndDistance;
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