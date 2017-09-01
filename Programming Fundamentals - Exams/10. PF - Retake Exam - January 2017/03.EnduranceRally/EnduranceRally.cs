namespace _03.EnduranceRally
{
    using System;
    using System.Linq;

    class EnduranceRally
    {
        static void Main()
        {
            string[] drivers = Console.ReadLine().Split(' ');
            double[] trackLength = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            int[] checkpoints = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            foreach (string driver in drivers)
            {
                double driverFuel = driver[0];

                for (int i = 0; i < trackLength.Length; i++)
                {
                    if (checkpoints.Contains(i))
                    {
                        driverFuel += trackLength[i];
                    }
                    else
                    {
                        driverFuel -= trackLength[i];
                    }

                    if (driverFuel <= 0)
                    {
                        Console.WriteLine($"{driver} - reached {i}");
                        break;
                    }
                }

                if (driverFuel > 0)
                {
                    Console.WriteLine($"{driver} - fuel left {driverFuel:F2}");
                }
            }
        }
    }
}
