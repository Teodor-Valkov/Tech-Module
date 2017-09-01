namespace _04.DrawFilledSquare
{
    using System;

    class DrawFilledSquare
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            PrintTopAndBottomLine(n);
            PrintMiddleLines(n);
            PrintTopAndBottomLine(n);
        }

        private static void PrintTopAndBottomLine(int number)
        {
            Console.WriteLine(new string('-', number * 2));
        }

        private static void PrintMiddleLines(int number)
        {
            for (int i = 0; i < number - 2; i++)
            {
                Console.Write("-");

                for (int j = 0; j < number - 1; j++)
                {
                    Console.Write("\\/");
                }

                Console.WriteLine("-");
            }
        }
    }
}
