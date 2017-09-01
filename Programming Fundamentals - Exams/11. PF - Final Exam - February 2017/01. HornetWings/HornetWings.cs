namespace _01.HornetWings
{
    using System;

    class HornetWings
    {
        static void Main()
        {
            long flapsToMake = long.Parse(Console.ReadLine());
            double distanceForThousandFlaps = double.Parse(Console.ReadLine());
            long endurance = long.Parse(Console.ReadLine());

            double allDistance = (flapsToMake / 1000) * distanceForThousandFlaps;

            double flyingTime = flapsToMake / 100;
            double restingTime = (flapsToMake / endurance) * 5;
            double allTime = flyingTime + restingTime;

            Console.WriteLine($"{allDistance:F2} m.");
            Console.WriteLine($"{allTime} s.");
        }
    }
}
