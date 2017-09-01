namespace _06.MaxSequenceOfEqualElements
{
    using System;
    using System.Linq;

    class MaxSequenceOfEqualElements
    {
        static void Main()
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int longestSequenceCount = 0;
            int numberOfTheSequence = 0;

            for (int start = 0; start < array.Length; start++)
            {
                int count = 1;

                while (start + count < array.Length && array[start] == array[start + count])
                {
                    count++;
                }

                if (count > longestSequenceCount)
                {
                    longestSequenceCount = count;
                    numberOfTheSequence = array[start];
                }

                start = start + count - 1;
            }

            for (int i = 0; i < longestSequenceCount; i++)
            {
                if (i == longestSequenceCount - 1)
                {
                    Console.WriteLine("{0}", numberOfTheSequence);
                }
                else
                {
                    Console.Write("{0} ", numberOfTheSequence);
                }
            }
        }
    }
}
