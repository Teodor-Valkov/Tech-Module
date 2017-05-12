namespace _03.Wormhole
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int[] wormholes = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int steps = 0;
            
            for (int i = 0; i < wormholes.Length; i++)
            {
                steps++;

                if (wormholes[i] != 0)
                {
                    int backToIndex = wormholes[i];

                    wormholes[i] = 0;
                    i = backToIndex;
                }
            }

            Console.WriteLine(steps);
        }
    }
}
