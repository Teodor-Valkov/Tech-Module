namespace _08.MostFrequentNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class MostFrequentNumber
    {
        private static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int longestSequenceCount = 0;
            int numberOfTheSequence = 0;

            foreach (int num in numbers)
            {
                int count = 0;

                foreach (int num2 in numbers)
                {
                    if (num == num2)
                    {
                        count++;
                    }

                    if (count > longestSequenceCount && num2 == numbers.Last())
                    {
                        longestSequenceCount = count;
                        numberOfTheSequence = num;
                    }
                }
            }

            Console.WriteLine(numberOfTheSequence);
        }
    }
}