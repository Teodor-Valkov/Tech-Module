namespace _03.Strawberry
{
    using System;

    internal class Strawberry
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int outsideDashes = 0;
            int insideDashes = n;
            int insideDots = 1;

            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}\\{1}|{1}/{0}", new string('-', outsideDashes), new string('-', insideDashes));
                outsideDashes += 2;
                insideDashes -= 2;
            }

            outsideDashes++;

            for (int i = 0; i <= n / 2; i++)
            {
                Console.WriteLine("{0}#{1}#{0}", new string('-', outsideDashes), new string('.', insideDots));
                outsideDashes -= 2;
                insideDots += 4;
            }

            Console.WriteLine("#{0}#", new string('.', n * 2 + 1));
            outsideDashes += 2;
            insideDots -= 4;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}#{1}#{0}", new string('-', outsideDashes), new string('.', insideDots));
                outsideDashes++;
                insideDots -= 2;
            }
        }
    }
}