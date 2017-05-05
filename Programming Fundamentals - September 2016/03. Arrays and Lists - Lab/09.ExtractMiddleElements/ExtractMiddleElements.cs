namespace _09.ExtractMiddleElements
{
    using System;
    using System.Linq;

    class ExtractMiddleElements
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            PrintMiddleElement(numbers);
            PrinMiddleEvenElements(numbers);
            PrintMiddleOddElements(numbers);
        }

        private static void PrintMiddleElement(int[] numbers)
        {
            if (numbers.Length == 1)
            {
                Console.Write("{ ");
                Console.Write("{0}", numbers[0]);
                Console.WriteLine(" }");
            }
        }

        private static void PrinMiddleEvenElements(int[] numbers)
        {
            if (numbers.Length % 2 == 0)
            {
                for (int i = 0; i < numbers.Length / 2; i++)
                {
                    if (i == numbers.Length / 2 - 1)
                    {
                        Console.Write("{ ");
                        Console.Write("{0}, {1}", numbers[i], numbers[i + 1]);
                        Console.WriteLine(" }");
                    }
                }
            }
        }

        private static void PrintMiddleOddElements(int[] numbers)
        {
            if (numbers.Length % 2 == 1)
            {
                for (int i = 0; i < numbers.Length / 2; i++)
                {
                    if (i == numbers.Length / 2 - 1)
                    {
                        Console.Write("{ ");
                        Console.Write("{0}, {1}, {2}", numbers[i], numbers[i + 1], numbers[i + 2]);
                        Console.WriteLine(" }");
                    }
                }
            }
        }
    }
}
