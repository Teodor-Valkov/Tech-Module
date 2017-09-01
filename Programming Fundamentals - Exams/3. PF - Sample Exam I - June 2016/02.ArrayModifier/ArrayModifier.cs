namespace _02.ArrayModifier
{
    using System;
    using System.Linq;

    class ArrayModifier
    {
        static void Main()
        {
            long[] numbers = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                if (command != null)
                {
                    string[] input = command.Split(' ');
                    string action = input[0];

                    switch (action)
                    {
                        case "swap": SwapElements(numbers, input); break;
                        case "multiply": MultiplyElements(numbers, input); break;
                        case "decrease": DecreaseElements(numbers); break;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void DecreaseElements(long[] numbers)
        {
            for (long i = 0; i < numbers.Length; i++)
            {
                numbers[i]--;
            }
        }

        private static void MultiplyElements(long[] numbers, string[] input)
        {
            long indexFirst = long.Parse(input[1]);
            long indexSecond = long.Parse(input[2]);

            numbers[indexFirst] *= numbers[indexSecond];
        }

        private static void SwapElements(long[] numbers, string[] input)
        {
            long indexFirst = long.Parse(input[1]);
            long indexSecond = long.Parse(input[2]);

            long temp = numbers[indexFirst];
            numbers[indexFirst] = numbers[indexSecond];
            numbers[indexSecond] = temp;
        }
    }
}
