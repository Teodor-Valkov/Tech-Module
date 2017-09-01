namespace _03.DressPatern
{
    using System;

    class DressPatern
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int outsideDashes = n * 4;
            int insideStars = 0;
            int insideMiddle = n * 6 + 2;
            int outsideMiddle = n * 3;

            Console.WriteLine("{0}.{0}.{0}", new string('_', outsideDashes));
            outsideDashes -= 2;
            insideStars += 2;

            for (int i = 0; i < n * 2; i++)
            {
                Console.WriteLine("{0}.{1}.{0}.{1}.{0}", new string('_', outsideDashes), new string('*', insideStars));
                outsideDashes -= 2;
                insideStars += 3;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(".{0}.", new string('*', n * 12));
            }

            for (int i = 0; i <= n; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("{0}{1}{0}", new string('.', outsideMiddle), new string('*', insideMiddle));                
                }
                else
                {
                    Console.WriteLine("{0}{1}{0}", new string('_', outsideMiddle), new string('o', insideMiddle));
                }
            }
            
            insideMiddle -= 2;

            for (int i = 0; i < n * 3; i++)
            {
                Console.WriteLine("{0}.{1}.{0}", new string('_', outsideMiddle), new string('*', insideMiddle));
                insideMiddle += 2;
                outsideMiddle--;
            }

            Console.WriteLine("{0}", new string('.', n * 12 + 2));
        }
    }
}
