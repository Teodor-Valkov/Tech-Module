namespace _04.ArrayModifier
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
                if (command == "decrease")
                {
                    for (long i = 0; i < numbers.Length; i++)
                    {
                        numbers[i]--;
                    }

                    command = Console.ReadLine();
                    continue;
                }

                if (command != null)
                {
                    string[] input = command.Split(' ');
                    string action = input[0];
                    long indexFirst = long.Parse(input[1]);
                    long indexSecond = long.Parse(input[2]);
                
                    if (action == "swap")
                    {
                        long temp = numbers[indexFirst];
                        numbers[indexFirst] = numbers[indexSecond];
                        numbers[indexSecond] = temp;
                    }
                    else if (action == "multiply")
                    {
                        numbers[indexFirst] *= numbers[indexSecond];
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
