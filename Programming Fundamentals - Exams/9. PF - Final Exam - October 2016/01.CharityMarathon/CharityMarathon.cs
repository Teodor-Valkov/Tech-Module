namespace _01.CharityMarathon
{
    using System;

    class CharityMarathon
    {
        static void Main()
        {
            int days = int.Parse(Console.ReadLine());
            long participants = long.Parse(Console.ReadLine());
            int lapsPerParticipant = int.Parse(Console.ReadLine());
            long trackLength = long.Parse(Console.ReadLine());
            int trackCapacity = int.Parse(Console.ReadLine());
            decimal moneyPerKilometer = decimal.Parse(Console.ReadLine());

            long allCapacity = days*trackCapacity;

            if (participants > allCapacity)
            {
                participants = allCapacity;
            }

            long totalMeters = participants*lapsPerParticipant*trackLength;
            long totalKilomenters = totalMeters/1000;
            
            decimal totalMoney = moneyPerKilometer*totalKilomenters;
            Console.WriteLine($"Money raised: {totalMoney:F2}");
        }
    }
}
