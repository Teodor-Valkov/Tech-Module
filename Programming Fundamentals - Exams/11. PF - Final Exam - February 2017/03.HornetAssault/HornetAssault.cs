namespace _03.HornetAssault
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class HornetAssault
    {
        static void Main()
        {
            List<long> beehives = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            List<long> hornets = Console.ReadLine().Split(' ').Select(long.Parse).ToList();

            for (int i = 0; i < beehives.Count; i++)
            {
                if (hornets.Count == 0)
                {
                    break;
                }

                long hornetsPower = hornets.Sum(hornet => hornet);

                if (beehives[i] >= hornetsPower)
                {
                    hornets.RemoveAt(0);
                    beehives[i] -= hornetsPower;
                }
                else
                {
                    beehives[i] -= hornetsPower;
                    //beehives.RemoveAt(i);
                    //i--;
                }
            }

            Console.WriteLine(beehives.Any(bee => bee > 0)
                ? string.Join(" ", beehives.Select(bee => bee > 0))
                : string.Join(" ", hornets));
        }
    }
}
