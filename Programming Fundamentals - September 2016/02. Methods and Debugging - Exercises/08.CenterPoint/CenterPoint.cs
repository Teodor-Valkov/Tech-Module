namespace _08.CenterPoint
{
    using System;

    class CenterPoint
    {
        static void Main()
        {
            double firstPointX = double.Parse(Console.ReadLine());
            double firstPointY = double.Parse(Console.ReadLine());
            double secondPointX = double.Parse(Console.ReadLine());
            double secondPointY = double.Parse(Console.ReadLine());

            double distanceFirstPoint = Math.Sqrt(Math.Pow(firstPointX - 0, 2) + Math.Pow(firstPointY - 0, 2));
            double distanceSecondPoint = Math.Sqrt(Math.Pow(secondPointX - 0, 2) + Math.Pow(secondPointY - 0, 2));

            string closestPointToTheCenter = FindTheClosestPoint(distanceFirstPoint, distanceSecondPoint);

            if (closestPointToTheCenter == "firstPoint")
            {
                Console.WriteLine("({0}, {1})", firstPointX, firstPointY);
            }
            else if (closestPointToTheCenter == "secondPoint")
            {
                Console.WriteLine("({0}, {1})", secondPointX, secondPointY);
            }
        }

        private static string FindTheClosestPoint(double distanceFirstPoint, double distanceSecondPoint)
        {
            if (distanceFirstPoint <= distanceSecondPoint)
                return "firstPoint";

            return "secondPoint";
        }
    }
}
