namespace _03.CirclesIntersection
{
    using System;
    using System.Linq;

    public class Circle
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }
    }

    class CirclesIntersection
    {
        static void Main()
        {
            Circle firstCircle = ReadCircle();
            Circle secondCircle = ReadCircle();

            bool answer = Intersect(firstCircle, secondCircle);

            Console.WriteLine("{0}", answer ? "Yes" : "No");
        }

        private static Circle ReadCircle()
        {
            double[] circleParameters = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            Circle currentCircle = new Circle()
            {
                X = circleParameters[0],
                Y = circleParameters[1],
                Radius = circleParameters[2]
            };

            return currentCircle;
        }

        private static bool Intersect(Circle firstCircle, Circle secondCircle)
        {
            bool result = false;
            double radiusSum = firstCircle.Radius + secondCircle.Radius;
            double distanceBetweenCenters = Math.Sqrt(Math.Pow(firstCircle.X - secondCircle.X, 2) +
                                                      Math.Pow(firstCircle.Y - secondCircle.Y, 2));
            if (radiusSum >= distanceBetweenCenters)
            {
                result = true;
            }

            return result;
        }
    }
}
