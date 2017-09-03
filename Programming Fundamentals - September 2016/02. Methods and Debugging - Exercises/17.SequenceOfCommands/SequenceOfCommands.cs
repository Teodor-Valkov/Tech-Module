namespace _17.SequenceOfCommands
{
    using System;
    using System.Linq;

    internal class SequenceOfCommands
    {
        private static void Main()
        {
            int sizeOfArray = int.Parse(Console.ReadLine());
            long[] array = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            string command = Console.ReadLine();

            while (command != null && command.ToLower() != "stop")
            {
                string[] stringParameters = command.Split(' ');
                string action = stringParameters[0];
                long[] values = new long[2];

                if (command.Contains("add") || command.Contains("subtract") || command.Contains("multiply"))
                {
                    values[0] = long.Parse(stringParameters[1]);
                    values[1] = long.Parse(stringParameters[2]);

                    PerformAction(array, action, values);
                }
                else
                {
                    PerformAction(array, action, values);
                }

                PrintArray(array);

                command = Console.ReadLine();
            }
        }

        private static void PerformAction(long[] array, string action, long[] values)
        {
            long pos = values[0] - 1;
            long value = values[1];

            switch (action)
            {
                case "multiply":
                    array[pos] *= value;
                    break;

                case "add":
                    array[pos] += value;
                    break;

                case "subtract":
                    array[pos] -= value;
                    break;

                case "lshift":
                    ArrayShiftLeft(array);
                    break;

                case "rshift":
                    ArrayShiftRight(array);
                    break;
            }
        }

        private static void ArrayShiftRight(long[] array)
        {
            long changedNumber = array[array.Length - 1];

            for (int i = array.Length - 1; i >= 1; i--)
            {
                array[i] = array[i - 1];
            }

            array[0] = changedNumber;
        }

        private static void ArrayShiftLeft(long[] array)
        {
            long changedNumber = array[0];

            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            array[array.Length - 1] = changedNumber;
        }

        private static void PrintArray(long[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                    Console.WriteLine(array[i]);
                else
                    Console.Write(array[i] + " ");
            }
        }
    }
}