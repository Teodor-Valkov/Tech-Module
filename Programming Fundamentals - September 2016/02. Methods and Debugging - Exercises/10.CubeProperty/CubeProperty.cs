namespace _10.CubeProperty
{
    using System;

    class CubeProperty
    {
        static void Main()
        {
            double side = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine();

            if (parameter == "face")
            {
                double faceDiagonal = GetFaceDiagonal(side);
                Console.WriteLine("{0:F2}", faceDiagonal);
            }
            else if (parameter == "space")
            {
                double spaceDiagonal = GetSpaceDiagonal(side);
                Console.WriteLine("{0:F2}", spaceDiagonal);
            }
            else if (parameter == "volume")
            {
                double volume = GetVolume(side);
                Console.WriteLine("{0:F2}", volume);
            }
            else if (parameter == "area")
            {
                double area = GetArea(side);
                Console.WriteLine("{0:F2}", area);
            }
        }

        private static double GetArea(double side)
        {
            return Math.Pow(side, 2) * 6;
        }

        private static double GetVolume(double side)
        {
            return Math.Pow(side, 3);
        }

        private static double GetSpaceDiagonal(double side)
        {
            return Math.Sqrt(3 * Math.Pow(side, 2));
        }

        private static double GetFaceDiagonal(double side)
        {
            return Math.Sqrt(2 * Math.Pow(side, 2));
        }
    }
}
