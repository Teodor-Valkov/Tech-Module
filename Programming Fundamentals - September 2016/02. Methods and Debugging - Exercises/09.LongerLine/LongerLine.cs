namespace _09.LongerLine
{
    using System;

    internal class LongerLine
    {
        private static void Main()
        {
            double firstPointX = double.Parse(Console.ReadLine());
            double firstPointY = double.Parse(Console.ReadLine());
            double secondPointX = double.Parse(Console.ReadLine());
            double secondPointY = double.Parse(Console.ReadLine());
            double thirdPointX = double.Parse(Console.ReadLine());
            double thirdPointY = double.Parse(Console.ReadLine());
            double fourthPointX = double.Parse(Console.ReadLine());
            double fourthPointY = double.Parse(Console.ReadLine());

            double firstPointDistanceToCenter = GetDistanceFromCenter(firstPointX, firstPointY);
            double secondPointDistanceToCenter = GetDistanceFromCenter(secondPointX, secondPointY);
            double thirdPointDistanceToCenter = GetDistanceFromCenter(thirdPointX, thirdPointY);
            double fourthPointDistanceToCenter = GetDistanceFromCenter(fourthPointX, fourthPointY);

            double lineBetweenFirstAndSecond = GetLineBetweenTwoPoints(firstPointX, firstPointY, secondPointX, secondPointY);
            double lineBetweenThirdAndFourth = GetLineBetweenTwoPoints(thirdPointX, thirdPointY, fourthPointX, fourthPointY);

            string longerLine = FindTheLongerLine(lineBetweenFirstAndSecond, lineBetweenThirdAndFourth);

            if (longerLine == "firstLine")
                if (firstPointDistanceToCenter <= secondPointDistanceToCenter)
                    Console.WriteLine("({0}, {1})({2}, {3})", firstPointX, firstPointY, secondPointX, secondPointY);
                else
                    Console.WriteLine("({0}, {1})({2}, {3})", secondPointX, secondPointY, firstPointX, firstPointY);
            else if (longerLine == "secondLine")
                if (thirdPointDistanceToCenter <= fourthPointDistanceToCenter)
                    Console.WriteLine("({0}, {1})({2}, {3})", thirdPointX, thirdPointY, fourthPointX, fourthPointY);
                else
                    Console.WriteLine("({0}, {1})({2}, {3})", fourthPointX, fourthPointY, thirdPointX, thirdPointY);
        }

        private static double GetDistanceFromCenter(double x, double y)
        {
            return Math.Sqrt(Math.Pow(x - 0, 2) + Math.Pow(y - 0, 2));
        }

        private static double GetLineBetweenTwoPoints(double firstX, double firstY, double secondX, double secondY)
        {
            return Math.Sqrt(Math.Pow(firstX - secondX, 2) + Math.Pow(firstY - secondY, 2));
        }

        private static string FindTheLongerLine(double firstLine, double secondLine)
        {
            if (firstLine >= secondLine)
                return "firstLine";

            return "secondLine";
        }
    }
}