namespace _14.ArrayManupulator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class ArrayManupulator
    {
        static void Main()
        {
            List<decimal> numbers = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();
            string[] input = Console.ReadLine().Split(' ');

            string action = input[0];

            while (action != "print")
            {
                int index;
                decimal element;

                switch (action)
                {
                    case "add":
                        index = int.Parse(input[1]);
                        element = decimal.Parse(input[2]);
                        numbers.Insert(index, element);
                        break;

                    case "addMany":
                        index = int.Parse(input[1]);
                        decimal[] elements = new decimal[input.Length - 2];
                        for (int i = 0; i < elements.Length; i++)
                        {
                            elements[i] = decimal.Parse(input[i + 2]);
                        }
                        numbers.InsertRange(index, elements);
                        break;

                    case "contains":
                        element = decimal.Parse(input[1]);
                        int position = numbers.IndexOf(element);
                        Console.WriteLine(position);
                        break;

                    case "remove":
                        index = int.Parse(input[1]);
                        numbers.RemoveAt(index);
                        break;

                    case "shift":
                        int rotations = int.Parse(input[1]);
                        rotations %= numbers.Count;
                        for (int i = 0; i < rotations; i++)
                        {
                            decimal currentNumber = numbers.First();
                            numbers.RemoveAt(0);
                            numbers.Add(currentNumber);
                        }
                        break;

                    case "sumPairs":
                        List<decimal> newNumbers = new List<decimal>();
                        for (int i = 0; i < numbers.Count - 1; i += 2)
                        {
                            newNumbers.Add(numbers[i] + numbers[i + 1]);
                        }
                        if (numbers.Count % 2 == 1)
                        {
                            newNumbers.Add(numbers[numbers.Count - 1]);
                        }
                        numbers = newNumbers;
                        break;
                }

                input = Console.ReadLine().Split();

                action = input[0];
            }

            Console.Write("[");
            Console.Write(string.Join(", ", numbers));
            Console.WriteLine("]");
        }
    }
}
