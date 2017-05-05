namespace _03.PrintingTriangle
{
    using System;

    class PrintingTriangle
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
     
            PrintUpperTrianglePart(n);

            PrintMiddleTrianglePart(n);

            PrintBottomTrianglePart(n);
        }

        private static void PrintUpperTrianglePart(int n)
        {
            for (int i = 1; i < n; i++)
            {
                PrintLine(1, i);
            }
        }

        private static void PrintMiddleTrianglePart(int n)
        {
            PrintLine(1, n);
        }

        private static void PrintBottomTrianglePart(int n)
        {
            for (int i = n - 1; i >= 0; i--)
            {
                PrintLine(1, i);
            }
        }

        private static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (i == end)
                    Console.WriteLine(i);
                else
                    Console.Write(i + " ");
            }
        }
    }
}
