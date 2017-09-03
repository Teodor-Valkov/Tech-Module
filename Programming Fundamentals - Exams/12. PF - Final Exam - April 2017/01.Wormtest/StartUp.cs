namespace _01.Wormtest
{
    using System;

    internal class StartUp
    {
        private static void Main()
        {
            double wormLength = double.Parse(Console.ReadLine()) * 100;
            double wormWidth = double.Parse(Console.ReadLine());

            double reminder = wormLength % wormWidth;

            if (reminder == 0 || wormLength == 0 || wormWidth == 0)
            {
                double product = wormLength * wormWidth;
                Console.WriteLine($"{product:F2}");
            }
            else
            {
                double percentage = (wormLength / wormWidth) * 100;
                Console.WriteLine($"{percentage:F2}%");
            }
        }
    }
}