namespace _03.Spyfer
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main()
        {
            List<long> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers.Count == 1)
                {
                    break;
                }

                if (i == 0)
                {
                    if (numbers[i] == numbers[i + 1])
                    {
                        numbers.RemoveAt(i + 1);
                        i = -1;
                    }
                }

                if (i == numbers.Count - 1)
                {
                    if (numbers[i] == numbers[i - 1])
                    {
                        numbers.RemoveAt(i - 1);
                        i = -1;
                    }
                }

                if (i > 0 && i < numbers.Count - 1)
                {
                    long previousNumber = numbers[i - 1];
                    long currentNumber = numbers[i];
                    long nextNumber = numbers[i + 1];

                    if (currentNumber == previousNumber + nextNumber)
                    {
                        numbers.RemoveAt(i + 1);
                        numbers.RemoveAt(i - 1);
                        i = -1;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
