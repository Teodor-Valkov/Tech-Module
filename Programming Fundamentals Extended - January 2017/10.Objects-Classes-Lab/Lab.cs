namespace _10.Objects_Classes_Lab
{
    using System;
    using System.Linq;
    using System.Numerics;
    using System.Globalization;
    using System.Collections.Generic;

    class Lab
    {
        static void Main()
        {
            // Task 1
            DayOfWeek();

            // Task 2
            RandomizeWords();

            // Task 3
            BigFactorial();

            // Task 4
            DistanceBetweenPoints();

            // Task 5
            ClosestTwoPoints();

            // Task 6
            RectanglePosition();

            // Task 7
            SalesReport();
        }

        private static void DayOfWeek()
        {
            // First Solution
            string dateAsString = Console.ReadLine();
            DateTime date = DateTime.ParseExact(dateAsString, "d-M-yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(date.DayOfWeek);

            // Second Solution
            int[] dateElements = Console.ReadLine().Split('-').Select(int.Parse).ToArray();
            DateTime date2 = new DateTime(dateElements[2], dateElements[1], dateElements[0]);
            Console.WriteLine(date2.DayOfWeek);
        }

        private static void RandomizeWords()
        {
            string[] words = Console.ReadLine().Split(' ');
            Random rnd = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int position = rnd.Next(0, words.Length);
                string oldValue = words[i];

                words[i] = words[position];
                words[position] = oldValue;
            }

            Console.WriteLine(string.Join("\n", words));
        }

        private static void BigFactorial()
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);
        }

        private static void DistanceBetweenPoints()
        {
            Point firstPoint = Point.ReadPoint();
            Point secondPoint = Point.ReadPoint();
            double hipotenus = Point.CalcDistance(firstPoint, secondPoint);

            Console.WriteLine($"{hipotenus:F3}");
        }

        private static void ClosestTwoPoints()
        {
            Point[] points = ClosestTwoPointsAndDistance.ReadArrayOfPoints();

            ClosestTwoPointsAndDistance closestTwoPointsAndDistance = ClosestTwoPointsAndDistance.FindClosestTwoPoints(points);

            Console.WriteLine($"{closestTwoPointsAndDistance.Distance:F3}");
            Console.WriteLine(closestTwoPointsAndDistance.First);
            Console.WriteLine(closestTwoPointsAndDistance.Second);
        }

        private static void RectanglePosition()
        {
            Rectangle r1 = Rectangle.ReadRectangle();
            Rectangle r2 = Rectangle.ReadRectangle();

            Console.WriteLine(r1.IsInside(r2) ? "Inside" : "Not inside");
        }

        private static void SalesReport()
        {
            int n = int.Parse(Console.ReadLine());

            List<Sale> sales = new List<Sale>();

            for (int i = 0; i < n; i++)
            {
                Sale currentSale = Sale.ReadSale();
                sales.Add(currentSale);
            }

            List<string> towns = sales.Select(x => x.Town).OrderBy(x => x).Distinct().ToList();

            foreach (string currentTown in towns)
            {
                double saleForTown = sales.Where(x => x.Town == currentTown).Sum(x => x.Price * x.Quantity);
                // saleForTown = sales.Where(x => x.town == currentTown).Select(x => x.price * x.quantity).Sum();

                Console.WriteLine($"{currentTown} -> {saleForTown:F2}");
            }
        }
    }

    public class Point
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
            double hipotenus = Math.Sqrt(triangleSideA * triangleSideA + triangleSideB * triangleSideB);

            return hipotenus;
        }

        public override string ToString()
        {
            return "Point(" + X + ", " + Y + ")";
        }
    }

    public class ClosestTwoPointsAndDistance
    {
        public Point First { get; set; }
        public Point Second { get; set; }
        public double Distance { get; set; }

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
                        };
                    }
                }
            }

            return closestTwoAndDistance;
        }

        public static double CalcDistance(Point firstPoint, Point secondPoint)
        {
            double triangleSideA = (firstPoint.X - secondPoint.X);
            double triangleSideB = (firstPoint.Y - secondPoint.Y);
            double hipotenus = Math.Sqrt(triangleSideA * triangleSideA + triangleSideB * triangleSideB);

            return hipotenus;
        }
    }

    public class Rectangle
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        // public int Bottom => Top + Height;
        public int Bottom
        {
            get
            {
                return Top + Height;
            }
        }

        // public int Right => Left + Width;
        public int Right
        {
            get
            {
                return Left + Width;
            }
        }

        public double CalculateArea()
        {
            return Width * Height;
        }

        public static Rectangle ReadRectangle()
        {
            int[] points = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Rectangle r = new Rectangle()
            {
                Left = points[0],
                Top = points[1],
                Width = points[2],
                Height = points[3]
            };

            return r;
        }

        public bool IsInside(Rectangle outer)
        {
            return
                outer.Left <= this.Left &&
                outer.Right >= this.Right &&
                outer.Top <= this.Top &&
                outer.Bottom >= this.Bottom;
        }

        public override string ToString()
        {
            return $"Rectangle (left = {Left}, top = {Top}, width = {Width}, height = {Height})";
        }
    }

    public class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }

        public static Sale ReadSale()
        {
            string[] input = Console.ReadLine().Split(' ');

            Sale itemsFromInput = new Sale()
            {
                Town = input[0],
                Product = input[1],
                Price = double.Parse(input[2]),
                Quantity = double.Parse(input[3])
            };

            return itemsFromInput;
        }
    }
}
